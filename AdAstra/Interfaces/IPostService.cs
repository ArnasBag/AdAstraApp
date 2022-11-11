using AdAstra.Dtos;

namespace AdAstra.Interfaces
{
    public interface IPostService
    {
        Task<PostViewDto> AddAsync(int tripId, string userId, PostPostDto postDto);
        Task DeleteAsync(int tripId, int postId, string userId);
        Task<List<PostViewDto>> GetAllAsync(int tripId);
        Task<PostViewDto> GetByIdAsync(int tripId, int postId);
        Task UpdateAsync(int tripId, int postId, string userId, PostPostDto postDto);
    }
}
