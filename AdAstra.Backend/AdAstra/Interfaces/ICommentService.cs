using AdAstra.Dtos;
using System.Security.Claims;

namespace AdAstra.Interfaces
{
    public interface ICommentService
    {
        Task<CommentViewDto> AddAsync(int tripId, int postId, CommentPostDto commentDto);
        Task DeleteAsync(int tripId, int postId, int commentId, ClaimsPrincipal user);
        Task<List<CommentViewDto>> GetAllAsync(int tripId, int postId);
        Task<CommentViewDto> GetByIdAsync(int tripId, int postId, int commentId);
        Task UpdateAsync(int tripId, int postId, int commentId, ClaimsPrincipal user, CommentPostDto commentDto);
    }
}
