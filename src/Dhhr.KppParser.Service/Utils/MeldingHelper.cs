using System;
using System.Linq;
using Dhhr.KppParser.Service.Models;

namespace Dhhr.KppParser.Service.Utils;

public static class MeldingHelper
{
    public static void Validate(Melding message)
    {
        ThrowIfContainsDuplicateInstitutionIds(message);
    }

    private static void ThrowIfContainsDuplicateInstitutionIds(Melding message)
    {
        if (message.ContainsDuplicateInstitutionIds(out var duplicateInstitutionIds))
        {
            throw new Exception("Den genererte meldingen inneholder duplikater av følgende institusjons-IDer: " + string.Join(", ", duplicateInstitutionIds));
        }
    }

    private static bool ContainsDuplicateInstitutionIds(this Melding message, out string[] duplicateInstitutionIds)
    {
        duplicateInstitutionIds = message.Institusjon
            .Select(i => i.institusjonID)
            .GroupBy(id => id)
            .Where(idGroup => idGroup.Count() > 1)
            .Select(duplicatedId => duplicatedId.Key)
            .ToArray();

        return duplicateInstitutionIds.Length > 0;
    }
}
