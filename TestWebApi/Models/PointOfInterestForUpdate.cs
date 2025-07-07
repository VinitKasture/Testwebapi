using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models
{
    public class PointOfInterestForUpdate
    {
        [Required(ErrorMessage = "Please provide name.")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
