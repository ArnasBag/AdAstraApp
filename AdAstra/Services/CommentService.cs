using AdAstra.DataAccess.Entities;
using AdAstra.DataAccess.Exceptions;
using AdAstra.DataAccess.Interfaces;
using AdAstra.Dtos;
using AdAstra.Exceptions;
using AdAstra.Interfaces;
using AutoMapper;
using System.Security.Claims;

namespace AdAstra.Services
{
    public class CommentService : ICommentService
    {
        private readonly IBaseRepository<Comment> _commentRepository;
        private readonly IBaseRepository<Trip> _tripRepository;
        private readonly IMapper _mapper;

        public CommentService(IBaseRepository<Comment> commentRepository, IBaseRepository<Trip> tripRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentViewDto>> GetAllAsync(int tripId, int postId)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            var post = trip.Posts.SingleOrDefault(p => p.Id == postId)
                ?? throw new EntityMissingInDatabaseException("Post with this id doesn't exist!");

            return _mapper.Map<List<CommentViewDto>>(post.Comments);
        }

        public async Task<CommentViewDto> GetByIdAsync(int tripId, int postId, int commentId)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            var post = trip.Posts.SingleOrDefault(p => p.Id == postId)
                ?? throw new EntityMissingInDatabaseException("Post with this id doesn't exist!");

            var comment = post.Comments.SingleOrDefault(c => c.Id == commentId)
                ?? throw new EntityMissingInDatabaseException("Comment with this id doesn't exist!");

            return _mapper.Map<CommentViewDto>(comment);
        }

        public async Task<CommentViewDto> AddAsync(int tripId, int postId, CommentPostDto commentDto)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            var post = trip.Posts.SingleOrDefault(p => p.Id == postId)
                ?? throw new EntityMissingInDatabaseException("Post with this id doesn't exist!");

            var commentEntity = _mapper.Map<Comment>(commentDto);
            commentEntity.CreatedDate = DateTime.Now;
            post.Comments.Add(commentEntity);

            await _commentRepository.AddAsync(commentEntity);

            return _mapper.Map<CommentViewDto>(commentEntity);
        }

        public async Task UpdateAsync(int tripId, int postId, int commentId, ClaimsPrincipal user, CommentPostDto commentDto)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            if(trip.ApplicationUserId != user.FindFirst("userId").Value && !user.IsInRole("Moderator"))
            {
                throw new ForbiddenException("You can only update your own comments!");
            }

            var post = trip.Posts.SingleOrDefault(p => p.Id == postId)
                ?? throw new EntityMissingInDatabaseException("Post with this id doesn't exist!");

            var comment = post.Comments.SingleOrDefault(c => c.Id == commentId)
                ?? throw new EntityMissingInDatabaseException("Comment with this id doesn't exist!");

            comment.UpdatedDate = DateTime.Now;
            comment.Body = commentDto.Body;

            await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteAsync(int tripId, int postId, int commentId, ClaimsPrincipal user)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            if (trip.ApplicationUserId != user.FindFirst("userId").Value && !user.IsInRole("Moderator"))
            {
                throw new ForbiddenException("You can only delete your own comments!");
            }

            var post = trip.Posts.SingleOrDefault(p => p.Id == postId)
                ?? throw new EntityMissingInDatabaseException("Post with this id doesn't exist!");

            var comment = post.Comments.SingleOrDefault(c => c.Id == commentId)
                ?? throw new EntityMissingInDatabaseException("Comment with this id doesn't exist!");

            await _commentRepository.DeleteAsync(comment);
        }
    }
}
