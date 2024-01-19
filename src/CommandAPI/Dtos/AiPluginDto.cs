using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CommandAPI.Dtos
{
    public class AiPluginDto
    {
        [JsonPropertyName("schema_version")]
        public string SchemaVersion { get; set; }

        [JsonPropertyName("name_for_model")]
        public string NameForModel { get; set; }

        [JsonPropertyName("name_for_human")]
        public string NameForHuman { get; set; }

        [JsonPropertyName("description_for_model")]
        public string DescriptionForModel { get; set; }

        [JsonPropertyName("description_for_human")]
        public string DescriptionForHuman { get; set; }

        [JsonPropertyName("auth")]
        public AuthDto Auth { get; set; }

        [JsonPropertyName("api")]
        public ApiDto Api { get; set; }

        [JsonPropertyName("logo_url")]
        public string LogoUrl { get; set; }

        [JsonPropertyName("contact_email")]
        public string ContactEmail { get; set; }

        [JsonPropertyName("legal_info_url")]
        public string LegalInfoUrl { get; set; }
    }

    public class AuthDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class ApiDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}