using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAstra.Dtos
{
    public class CommentPostDto
    {
        [Required]
        public string Body { get; set; }
    }
}
