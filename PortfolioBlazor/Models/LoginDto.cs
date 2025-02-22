using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PortfolioBlazor.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Invalid username or password.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Invalid username or password.")]
        public string Password { get; set; }

        [JsonPropertyName("detail")]
        public string? detail { get; set; }
    }


}
