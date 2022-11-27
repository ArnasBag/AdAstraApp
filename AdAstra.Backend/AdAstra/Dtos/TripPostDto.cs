using System.ComponentModel.DataAnnotations;

namespace AdAstra.Dtos
{
    public class TripPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
