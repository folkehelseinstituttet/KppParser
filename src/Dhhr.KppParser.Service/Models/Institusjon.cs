using System.Collections.Generic;

namespace Dhhr.KppParser.Service.Models
{
    public partial class Institusjon
    {
        public static Institusjon Create(string institusjonId, List<EpisodeKPP> episoder)
        {
            return new Institusjon
            {
                institusjonID = institusjonId,
                Objektholder = new []
                {
                    new Objektholder
                    {
                        pasientNr = "-1",
                        EpisodeKPP = episoder.ToArray()
                    }
                }
            };
        }
    }
}
