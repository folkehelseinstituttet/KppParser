using System;
using System.Collections.Generic;
using System.Linq;
using Dhhr.KppParser.Service.Models;

namespace Dhhr.KppParser.Service.Utils;

public static class BatchMessageUtils
{
    private static IEnumerable<Melding> CreateMeldinger(Args args, int batchMessageCount)
    {
        // TODO Rather than customizing the lopenr value for batch messages here, should MT2.0 instead manage to handle lopenr values that are not convertible to int?
        var lopenr = DateTime.UtcNow.Ticks % int.MaxValue; // lopenr needs to be convertible to an int for Dhhr.Meldingstjener to handle it

        var institusjonerPerMelding = ParseFiles(args.EpisodePath, args.TjenestePath, batchMessageCount);

        for (var i = 0; i < batchMessageCount; i++)
        {
            var lokalident = $"{lopenr}_({i + 1}_Of_{batchMessageCount})";

            var institusjonerForMelding = institusjonerPerMelding[i];

            yield return MessageUtils.BuildMelding(args, lopenr.ToString(), lokalident, institusjonerForMelding);
        }
    }

    private static List<Institusjon[]> ParseFiles(string episodePath, string tjenestePath, int batchMessageCount)
    {
        var episoder = MessageUtils.ParseInputFiles(episodePath, tjenestePath);

        // TODO Distribute episoder appropriately for each batch message
        return [episoder
            .Select(kpps => Institusjon.Create(kpps.Key, kpps.ToList()))
            .ToArray()];
    }
}
