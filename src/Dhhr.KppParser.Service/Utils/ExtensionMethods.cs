using System;
using System.Globalization;

namespace Dhhr.KppParser.Service.Utils
{
    public static class ExtensionMethods
    {
        public static decimal? AsDecimal(this string total)
        {
            if (total == null)
            {
                return null;
            }

            const NumberStyles numberStyles =
                NumberStyles.AllowDecimalPoint
                | NumberStyles.AllowLeadingWhite
                | NumberStyles.AllowTrailingWhite
                | NumberStyles.AllowLeadingSign;

            if (decimal.TryParse(total, numberStyles, new CultureInfo("NB-no"), out var result))
            {
                return result;
            }

            if (decimal.TryParse(total, numberStyles, CultureInfo.InvariantCulture, out var ret))
            {
                return ret;
            }

            throw new ArgumentException($"Input string ({total}) was not in a correct format. Supported NumberStyles: {numberStyles}. Supported CultureInfo: NB-no, InvariantCulture.");
        }
    }
}
