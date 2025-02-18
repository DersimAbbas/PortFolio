using System.Text.Json.Serialization;

namespace PortfolioBlazor.Models
{
    public class TechsModel
    {
        
        
        [JsonPropertyName("technologies")]
        public string Technologies { get; set; }

        [JsonPropertyName("techExperience")]
        public string TechExperience { get; set; }

        [JsonPropertyName("skillLevel")]
        public double SkillLevel { get; set; }
    }


}

