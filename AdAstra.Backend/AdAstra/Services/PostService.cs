using AdAstra.DataAccess.Entities;
using AdAstra.DataAccess.Exceptions;
using AdAstra.DataAccess.Interfaces;
using AdAstra.Dtos;
using AdAstra.Exceptions;
using AdAstra.Interfaces;
using AutoMapper;

namespace AdAstra.Services
{
    public class PostService : IPostService
    {
        private readonly IBaseRepository<Post> _postRepository;
        private readonly IBaseRepository<Trip> _tripRepository;
        private readonly IMapper _mapper;

        public PostService(IMapper mapper, IBaseRepository<Post> postRepository, IBaseRepository<Trip> tripRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _tripRepository = tripRepository;
        }

        public async Task<List<PostViewDto>> GetAllAsync(int tripId)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            return _mapper.Map<List<PostViewDto>>(trip.Posts);
        }

        public async Task<PostViewDto> GetByIdAsync(int tripId, int postId)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            var post = trip.Posts.SingleOrDefault(p => p.Id == postId)
                ?? throw new EntityMissingInDatabaseException("Post with this id doesn't exist!");

            return _mapper.Map<PostViewDto>(post);
        }

        public async Task<PostViewDto> AddAsync(int tripId, string userId, PostPostDto postDto)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            if (trip.ApplicationUserId != userId)
            {
                throw new ForbiddenException("You can only add posts to your own trips!");
            }

            var postEntity = _mapper.Map<Post>(postDto);
            trip.Posts.Add(postEntity);

            await _postRepository.AddAsync(postEntity);
            return _mapper.Map<PostViewDto>(postEntity);
        }

        public async Task UpdateAsync(int tripId, int postId, string userId, PostPostDto postDto)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            if (trip.ApplicationUserId != userId)
            {
                throw new ForbiddenException("You can only update your own posts!");
            }

            var post = trip.Posts.SingleOrDefault(p => p.Id == postId)
                ?? throw new EntityMissingInDatabaseException("Post with this id doesn't exist!");

            post.Title = postDto.Title;
            post.PhotoUrl = postDto.PhotoUrl;
            post.Review = postDto.Review;

            await _postRepository.UpdateAsync(post);
        }

        public async Task DeleteAsync(int tripId, int postId, string userId)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            if (trip.ApplicationUserId != userId)
            {
                throw new ForbiddenException("You can only delete your own trips!");
            }

            var post = trip.Posts.SingleOrDefault(p => p.Id == postId)
                ?? throw new EntityMissingInDatabaseException("Post with this id doesn't exist!");

            try
            {
                await _postRepository.DeleteAsync(post);
            }
            catch(InvalidOperationException ex)
            {
                throw new CascadeDeleteRestrictedException("Cannot delete post because it has comments associated with it!");
            }
        }
    }
}
