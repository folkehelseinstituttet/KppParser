using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dhhr.KppParser.Service.Models;

namespace Dhhr.KppParser.Service.Utils;

public static class MessageUtils
{
    public static Melding CreateMelding(Args args)
    {
        var lopenr = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");
        var lokalident = Guid.NewGuid().ToString();

        var institusjoner = ParseFiles(args.EpisodePath, args.TjenestePath);

        return BuildMelding(args, lopenr, lokalident, institusjoner);
    }

    public static Melding BuildMelding(Args args, string lopenr, string lokalident, Institusjon[] institusjoner)
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
            Institusjon = institusjoner,
        };
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

    public static IEnumerable<IGrouping<string, EpisodeKPP>> ParseInputFiles(string episodePath, string tjenestePath)
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

        return episoder;
    }

    private static Institusjon[] ParseFiles(string episodePath, string tjenestePath)
    {
        var episoder = ParseInputFiles(episodePath, tjenestePath);

        return episoder
            .Select(kpps => Institusjon.Create(kpps.Key, kpps.ToList()))
            .ToArray();
    }
}
