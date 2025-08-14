using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dhhr.KppParser.Service.Models;

namespace Dhhr.KppParser.Service.Utils;

public static class BatchMessageUtils
{
    public static void TryCreateFiles(Args args, Action<int, string> reportStatus, Action<string> userNotificator, Melding message, int fileCount)
    {
        if (CanCreateFiles(message, out var institution))
        {
            userNotificator?.Invoke("Meldingen er for stor for sending. Starter prosess for å generere flere mindre delmeldinger...");
            CreateFiles(args, reportStatus, institution, fileCount);

            return;
        }

        userNotificator?.Invoke("Meldingen er for stor for sending, og inneholder flere institusjon-IDer." +
                                " Vennligst del opp episode- og tjeneste-filene i separate filer per institusjon, og bruk dette programmet til å lage én KPP-melding for hver institusjon." +
                                Environment.NewLine + Environment.NewLine +
                                " Avbryter den pågående prosessen.");

        reportStatus?.Invoke(45, "Prosess avbrutt.");
    }

    private static void CreateFiles(
        Args args,
        Action<int, string> reportStatus,
        Institusjon institution,
        int batchFileCount)
    {
        reportStatus?.Invoke(5, "Prosess for generering av delmeldinger har startet.");
        reportStatus?.Invoke(10, "Leser data...");
        var messages = CreateMessages(args, institution, batchFileCount).ToList();

        var wrappedMessageByOutputPath = messages
            .Select(message => (
                OutputPath: BuildFileName(message, args.OutputPath),
                WrappedMessage: MessageUtils.WrapInMsgHead(message, args)))
            .ToList();

        reportStatus?.Invoke(50, "Lagrer delmeldinger...");

        Directory.CreateDirectory(Path.GetDirectoryName(args.OutputPath));

        foreach (var message in wrappedMessageByOutputPath)
        {
            XmlUtils.SerializeToFile(message.WrappedMessage, message.OutputPath);
        }

        reportStatus?.Invoke(75, "Kontrollerer delmeldinger...");
        var schemas = SchemaLoader.LoadDirectory("Resources");

        foreach (var message in wrappedMessageByOutputPath)
        {
            XmlUtils.ValidateXmlFile(message.OutputPath, schemas);
        }

        reportStatus?.Invoke(100, "Ferdig");
    }

    private static bool CanCreateFiles(Melding message, out Institusjon forInstitution)
    {
        if (MessageUtils.HasSingleInstitution(message))
        {
            forInstitution = message.Institusjon.Single();
            return true;
        }

        forInstitution = null;
        return false;
    }

    private static string BuildFileName(Melding message, string fileName)
    {
        var extensionIndex = fileName.LastIndexOf('.');

        return fileName.Insert(extensionIndex, "_" + message.lokalident);
    }

    private static IEnumerable<Melding> CreateMessages(Args args, Institusjon institution, int batchFileCount)
    {
        // TODO If MT2.0 is customized to support other lopenr datatypes than int: replace with MessageUtils.CreateLopenr()
        var lopenr = CreateLopenr();

        var episodes = institution.Objektholder.Single().EpisodeKPP;

        var episodesPerMessage = episodes
            .Chunk(episodes.Length / batchFileCount)
            .ToList();

        for (var i = 0; i < batchFileCount; i++)
        {
            var lokalident = $"{lopenr}_({i + 1}_Of_{batchFileCount})";

            var institutionObject = Institusjon.Create(institution.institusjonID, episodesPerMessage[i]);

            yield return MessageUtils.BuildMessage(args, lopenr, lokalident, [institutionObject]);
        }
    }

    private static string CreateLopenr() => (DateTime.UtcNow.Ticks % int.MaxValue).ToString();
}
