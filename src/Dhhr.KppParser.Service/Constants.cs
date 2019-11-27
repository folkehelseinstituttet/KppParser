namespace Dhhr.KppParser.Service
{
    public static class Constants
    {
        public const string DateMismatch = "Startdato er større enn sluttdato.";
        public const string InvalidOrgName = "Org. navn: Ugyldig (Kan ikke være tomt)";
        public const string InvalidSenderHerId = "Org. HerId: Ugyldig HerId";

        public static class Episode
        {
            public const string EmptyFileName = "Episode: Feltet er tomt.";
            public const string DoesNotExist = "Episode: Filen finnes ikke.";
            public const string InvalidHeader = "Episode: Filen har feil i header eller mangler header.";
        }

        public static class Tjeneste
        {
            public const string EmptyFileName = "Tjeneste: Feltet er tomt.";
            public const string DoesNotExist = "Tjeneste: Filen finnes ikke.";
            public const string InvalidHeader = "Tjeneste: Filen har feil i header eller mangler header.";
        }
    }
}
