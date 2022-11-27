using AdAstra.DataAccess.Data;
using AdAstra.DataAccess.Entities;

namespace AdAstra.DataAccess.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
