using AdAstra.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAstra.Dtos
{
    public class PostViewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string Review { get; set; }
        public List<CommentViewDto> Comments { get; set; }
    }
}
