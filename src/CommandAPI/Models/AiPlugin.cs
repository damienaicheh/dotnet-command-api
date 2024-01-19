namespace CommandAPI.Models
{
    public class AiPlugin
    {
        public string SchemaVersion { get; set; }
        public string NameForModel { get; set; }
        public string NameForHuman { get; set; }
        public string DescriptionForModel { get; set; }
        public string DescriptionForHuman { get; set; }
        public Auth Auth { get; set; }
        public Api Api { get; set; }
        public string LogoUrl { get; set; }
        public string ContactEmail { get; set; }
        public string LegalInfoUrl { get; set; }
    }

    public class Auth
    {
        public string Type { get; set; }
    }

    public class Api
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }
}