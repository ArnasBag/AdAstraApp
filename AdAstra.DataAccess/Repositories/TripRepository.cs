using AdAstra.DataAccess.Data;
using AdAstra.DataAccess.Entities;
using AdAstra.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AdAstra.DataAccess.Repositories
{
    public class TripRepository : BaseRepository<Trip>
    {
        public TripRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override async Task<Trip> GetByIdAsync(int id)
        {
            return await _context.Trips.Include(t => t.Posts)
                .ThenInclude(p => p.Comments)
                .SingleOrDefaultAsync(t => t.Id == id)
                ?? throw new EntityMissingInDatabaseException("Trip with this id doesn't exist!");
        }

        public async Task ThrowIfNotFound(int id)
        {
            await GetByIdAsync(id);
        }
    }
}
