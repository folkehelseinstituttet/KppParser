using System;
using System.IO;
using System.Linq;
using System.Xml;
using Dhhr.KppParser.Service.Models;

namespace Dhhr.KppParser.Service.Utils;

public static class MessageUtils
{
    public static Melding CreateMessage(Args args, Institusjon[] institutions)
    {
        return BuildMessage(args, CreateLopenr(), CreateLokalident(), institutions);
    }

    public static Melding BuildMessage(Args args, string lopenr, string lokalident, Institusjon[] institutions)
    {
        return new Melding
        {
            lopenr = lopenr,
            lokalident = lokalident,
            uttakDato = DateTime.Today,
            versjonUt = args.ProgramVersion,
            meldingstype = "B",
            fraDatoPeriode = args.FraDato,
            tilDatoPeriode = args.TilDato,
            leverandor = args.Leverandor,
            navnEPJ = args.NavnEpj,
            versjonEPJ = args.VersjonEpj,
            Institusjon = institutions,
        };
    }

    public static Melding BuildBatchMessage(Args args, string lopenr, string batchInfo, Institusjon institution)
    {
        var lokalident = lopenr + "_" + batchInfo;

        return BuildMessage(args, lopenr, lokalident, [institution]);
    }

    public static MsgHead WrapInMsgHead(Melding melding, Args args)
    {
        return new MsgHead
        {
            Items = new object[]
            {
                new Document
                {
                    RefDoc = new RefDoc
                    {
                        MsgType = new CS { V = "XML", DN = "XML-instans" },
                        Item = new RefDocContent { Melding = melding }
                    }
                }
            },
            MsgInfo = new MsgInfo
            {
                Type = new CS { V = "NPR_KPP", DN = "KPP melding" },
                GenDate = DateTime.Now,
                MsgId = Guid.NewGuid().ToString(),
                Sender = new Sender
                {
                    Organisation = new Organisation
                    {
                        OrganisationName = args.OrganizationName,
                        Ident = new []
                        {
                            new Ident
                            {
                                Id = args.OrganizationHerId,
                                TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" }
                            }
                        },
                        Organisation1 = new Organisation
                        {
                            OrganisationName = args.OrganizationName2,
                            Ident = new[]
                            {
                                new Ident
                                {
                                    Id = args.OrganizationHerId2,
                                    TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" }
                                }
                            }
                        }
                    }
                },
                Receiver = new Receiver
                {
                    Organisation = new Organisation
                    {
                        OrganisationName = "FHI",
                        Ident = new[]
                        {
                            new Ident
                            {
                                Id = "85217",
                                TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" }
                            }
                        },
                        Organisation1 = new Organisation
                        {
                            OrganisationName = "NPR",
                            Ident = new []
                            {
                                new Ident
                                {
                                    Id = args.FhiHerId,
                                    TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" }
                                }
                            }
                        }
                    }
                }
            }
        };
    }

    public static bool HasSingleInstitution(Melding message) => message.Institusjon.Length == 1;

    public static Institusjon[] ParseFiles(string episodePath, string tjenestePath)
    {
        var tjenester = File.ReadLines(tjenestePath)
            .Skip(1) // skip header
            .Select(line => line.Split(';', StringSplitOptions.TrimEntries))
            .ToLookup(
                parts => parts[0], // episodeID
                parts => TjenesteKPP.Create(parts[1], parts[2]));

        var episoder = File.ReadLines(episodePath)
            .Skip(1) // skip header
            .Select(line => line.Split(';', StringSplitOptions.TrimEntries))
            .GroupBy(
                parts => parts[0], // institusjonID
                parts => EpisodeKPP.Create(parts[1], parts[2], parts[3], tjenester[parts[1]]));

        return episoder
            .Select(kpps => Institusjon.Create(kpps.Key, kpps.ToArray()))
            .ToArray();
    }

    public static bool ShouldCreateBatchFiles(Args args, XmlDocument xmlDocument, out int recommendedFileCount)
    {
        if (args.BatchFiles.EnableCreation)
        {
            var maxFileSizeInBytes = args.BatchFiles.MaxFileSizeInBytes;

            if (FileExceedsMaxFileSize(xmlDocument, maxFileSizeInBytes, out var fileSizeInBytes))
            {
                recommendedFileCount = BatchMessageUtils.GetRecommendedFileCount(fileSizeInBytes, maxFileSizeInBytes);

                return true;
            }
        }

        recommendedFileCount = 0;
        return false;
    }

    private static bool FileExceedsMaxFileSize(XmlDocument xmlDocument, long maxFileSizeInBytes, out long fileSizeInBytes)
    {
        // TODO Does this result in the right value for large files (> 1 GB)?
        fileSizeInBytes = XmlUtils.Encoding.GetBytes(xmlDocument.OuterXml).LongLength;

        return fileSizeInBytes > maxFileSizeInBytes;
    }

    private static string CreateLopenr() => DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");

    private static string CreateLokalident() => Guid.NewGuid().ToString();
}
