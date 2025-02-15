using System.Text.Json.Serialization;

namespace PortfolioBlazor.Models
{
    public class TechsModel
    {
        [JsonPropertyName("tech")]
        public string Tech { get; set; }

        [JsonPropertyName("techExperience")]
        public string TechExperience { get; set; }

        [JsonPropertyName("skillLevel")]
        public string SkillLevel { get; set; }
    }


}

