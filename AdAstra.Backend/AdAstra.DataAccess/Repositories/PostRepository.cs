using AdAstra.DataAccess.Data;
using AdAstra.DataAccess.Entities;
using AdAstra.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AdAstra.DataAccess.Repositories
{
    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {

        }
        public override async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.Include(t => t.Comments)
                .SingleOrDefaultAsync(t => t.Id == id)
                ?? throw new EntityMissingInDatabaseException("Post with this id doesn't exist!");
        }
    }
}
