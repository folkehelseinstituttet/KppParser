using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dhhr.KppParser.Service.Models;

namespace Dhhr.KppParser.Service.Utils;

public static class BatchMessageUtils
{
    // The buffer is slightly larger than the base size of the generated file (before the file is populated with episode content)
    private const int BaseFileSizeInBytes = 3000;

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

    public static int GetRecommendedFileCount(long fileSizeInBytes, long maxFileSizeInBytes)
    {
        var fileCountWithMaxFileSize = (int)Math.DivRem(fileSizeInBytes, maxFileSizeInBytes, out var remainingFileSizeInBytes);

        var recommendedFileCount = 1 + fileCountWithMaxFileSize;

        // Account for the base size of each generated file (i.e. everything around the episode content)
        var actualTotalFileSizeBuffer = maxFileSizeInBytes - remainingFileSizeInBytes;
        var neededTotalFileSizeBuffer = recommendedFileCount * BaseFileSizeInBytes;

        if (actualTotalFileSizeBuffer < neededTotalFileSizeBuffer)
        {
            return 1 + recommendedFileCount;
        }

        return recommendedFileCount;
    }

    private static void CreateFiles(
        Args args,
        Action<int, string> reportStatus,
        Institusjon institution,
        int batchFileCount)
    {
        reportStatus?.Invoke(5, "Prosess for generering av delmeldinger har startet.");
        reportStatus?.Invoke(10, "Leser data...");
        var batchedInstitutionObjects = GetBatchedInstitutionObjects(institution, batchFileCount).ToList();

        var lopenr = CreateLopenr();

        var wrappedMessageByOutputPath = batchedInstitutionObjects
            .Select(batch => (
                batch.BatchInfo,
                Message: MessageUtils.BuildBatchMessage(args, lopenr, batch.BatchInfo, batch.Institution)))
            .Select(batchObject => (
                OutputPath: BuildFileName(batchObject.BatchInfo, args.OutputPath),
                WrappedMessage: MessageUtils.WrapInMsgHead(batchObject.Message, args)))
            .ToList();

        reportStatus?.Invoke(50, "Lagrer delmeldinger...");

        Directory.CreateDirectory(Path.GetDirectoryName(args.OutputPath));

        foreach (var message in wrappedMessageByOutputPath)
        {
            var xml = XmlUtils.SerializeToXmlDocument(message.WrappedMessage);
            XmlUtils.SaveToFile(xml, message.OutputPath);
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

    private static string BuildFileName(string batchInfo, string fileName)
    {
        var extensionIndex = fileName.LastIndexOf('.');

        return fileName.Insert(extensionIndex, "_" + batchInfo);
    }

    private static IEnumerable<(Institusjon Institution, string BatchInfo)> GetBatchedInstitutionObjects(Institusjon institution, int batchFileCount)
    {
        var episodes = institution.Objektholder.Single().EpisodeKPP;

        var episodesPerMessage = episodes
            .Chunk(episodes.Length / batchFileCount)
            .ToList();

        for (var i = 0; i < batchFileCount; i++)
        {
            var batchInfo = $"({i + 1}_Of_{batchFileCount})";

            var institutionObject = Institusjon.Create(institution.institusjonID, episodesPerMessage[i]);

            yield return (institutionObject, batchInfo);
        }
    }

    private static string CreateLopenr() => (DateTime.UtcNow.Ticks % int.MaxValue).ToString();
}
