using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PortfolioBlazor.Models
{
    public class TechsModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("project")]
        public string? project { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("githubUrl")]
        public string? githubUrl { get; set; }

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
        public string? image { get; set; }

        [JsonPropertyName("demoUrl")]
        public string? DemoUrl { get; set; }

        [JsonPropertyName("level")]
        public string Level { get; set; }
        public List<string> TechnologiesList => Technologies.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                       .Select(t => t.Trim())
                                                       .ToList();
        public List<string> ImageList => image.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(img => img.Trim())
                                      .ToList();
    }
}
