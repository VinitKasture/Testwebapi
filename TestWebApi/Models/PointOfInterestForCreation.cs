using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    public class PointOfInterestForCreation
    {
        [Required(ErrorMessage = "Please provide name.")]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
