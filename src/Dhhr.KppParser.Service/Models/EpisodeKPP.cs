using System;
using System.Collections.Generic;
using System.Linq;
using Dhhr.KppParser.Service.Utils;

namespace Dhhr.KppParser.Service.Models
{
    public partial class EpisodeKPP
    {
        public static EpisodeKPP Create(string episodeId, string drg, string total, IEnumerable<TjenesteKPP> tjenester)
        {
            return new EpisodeKPP
            {
                episodeID = episodeId,
                totalSpecified = total != null,
                total = total.AsDecimal() ?? 0,
                drg = string.Equals(drg, "(tom)", StringComparison.InvariantCultureIgnoreCase) ? null : drg,
                TjenesteKPP = tjenester.ToArray(),
            };
        }
    }
}
