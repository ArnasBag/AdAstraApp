using AdAstra.Dtos;
using AdAstra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdAstra.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("trips/{tripId}/posts")]
        public async Task<IActionResult> GetAllPosts(int tripId)
        {
            var posts = await _postService.GetAllAsync(tripId);

            return Ok(posts);
        }

        [HttpGet("trips/{tripId}/posts/{postId}")]
        public async Task<IActionResult> GetPostById(int tripId, int postId)
        {
            var post = await _postService.GetByIdAsync(tripId, postId);

            return Ok(post);
        }

        [Authorize(Roles = "User")]
        [HttpPost("trips/{tripId}/posts")]
        public async Task<IActionResult> AddPost(int tripId, PostPostDto request)
        {
            var post = await _postService.AddAsync(tripId, User.FindFirst("userId").Value, request);

            return CreatedAtAction(nameof(GetPostById), new { tripId, postId = post.Id }, post);
        }

        [Authorize(Roles = "User")]
        [HttpPut("trips/{tripId}/posts/{postId}")]
        public async Task<IActionResult> UpdatePost(int tripId, int postId, PostPostDto request)
        {
            await _postService.UpdateAsync(tripId, postId, User.FindFirst("userId").Value, request);

            return NoContent();
        }

        [Authorize(Roles = "User")]
        [HttpDelete("trips/{tripId}/posts/{postId}")]
        public async Task<IActionResult> DeletePost(int tripId, int postId)
        {
            await _postService.DeleteAsync(tripId, postId, User.FindFirst("userId").Value);

            return NoContent();
        }
    }
}
