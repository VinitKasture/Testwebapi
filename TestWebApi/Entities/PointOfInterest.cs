using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApi.Entities
{
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }

        public PointOfInterest(string name) 
        {
            Name = name;
        }
    }
}
