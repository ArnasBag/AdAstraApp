using AdAstra.Dtos;

namespace AdAstra.Interfaces
{
    public interface ITripService
    {
        Task<TripViewDto> AddAsync(string userId, TripPostDto tripDto);
        Task DeleteAsync(int id, string userId);
        Task<List<TripViewDto>> GetAllAsync();
        Task<TripViewDto> GetByIdAsync(int id);
        Task UpdateAsync(int tripId, string userId, TripPostDto tripDto);
    }
}
