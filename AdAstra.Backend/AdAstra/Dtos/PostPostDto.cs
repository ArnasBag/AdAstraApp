using System.ComponentModel.DataAnnotations;

namespace AdAstra.Dtos
{
    public class PostPostDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
        [Required]
        public string Review { get; set; }
    }
}
