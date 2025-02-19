using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PortfolioBlazor.Models
{
    public class TechsModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Technology Name is required.")]
        [JsonPropertyName("technologies")]
        public string Technologies { get; set; }

        [JsonPropertyName("techExperience")]
        [Required(ErrorMessage = "Technology Experience is required.")]
        public string TechExperience { get; set; }

        [JsonPropertyName("skillLevel")]
        [Required(ErrorMessage = "Skill level is required.")]
        public double SkillLevel { get; set; }
        [JsonPropertyName("image")]
        public string? Image { get; set; }
    }
}
