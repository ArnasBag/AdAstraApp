using AdAstra.Dtos;
using AdAstra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdAstra.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("trips/{tripId}/posts/{postId}/comments")]
        public async Task<IActionResult> GetAllComments(int tripId, int postId)
        {
            var comments = await _commentService.GetAllAsync(tripId, postId);

            return Ok(comments);
        }

        [HttpGet("trips/{tripId}/posts/{postId}/comments/{commentId}")]
        public async Task<IActionResult> GetCommentById(int tripId, int postId, int commentId)
        {
            var comment = await _commentService.GetByIdAsync(tripId, postId, commentId);

            return Ok(comment);
        }

        [Authorize(Roles = "User")]
        [HttpPost("trips/{tripId}/posts/{postId}/comments")]
        public async Task<IActionResult> AddComment(int tripId, int postId, CommentPostDto request)
        {
            var comment = await _commentService.AddAsync(tripId, postId, request);

            return CreatedAtAction(nameof(GetCommentById), new { tripId, postId, commentId = comment.Id}, comment);
        }

        [Authorize(Roles = "User")]
        [HttpPut("trips/{tripId}/posts/{postId}/comments/{commentId}")]
        public async Task<IActionResult> UpdateComment(int tripId, int postId, int commentId, CommentPostDto request)
        {
            await _commentService.UpdateAsync(tripId, postId, commentId, User, request);
            return NoContent();
        }

        [Authorize(Roles = "User")]
        [HttpDelete("trips/{tripId}/posts/{postId}/comments/{commentId}")]
        public async Task<IActionResult> DeleteComment(int tripId, int postId, int commentId)
        {
            await _commentService.DeleteAsync(tripId, postId, commentId, User);

            return NoContent();
        }
    }
}
