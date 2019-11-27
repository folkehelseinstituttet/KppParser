using System;
using Dhhr.KppParser.Service.Utils;

namespace Dhhr.KppParser.Service.Models
{
    public partial class TjenesteKPP
    {
        public static TjenesteKPP Create(string kostnadskode, string kostnad)
        {
            return new TjenesteKPP
            {
                kostnadKode = kostnadskode,
                kostnad = kostnad.AsDecimal() ?? throw new NullReferenceException()
            };
        }
    }
}
