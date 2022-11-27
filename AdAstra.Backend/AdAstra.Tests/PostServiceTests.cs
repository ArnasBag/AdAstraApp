using AdAstra.DataAccess.Entities;
using AdAstra.DataAccess.Exceptions;
using AdAstra.DataAccess.Interfaces;
using AdAstra.Dtos;
using AdAstra.Exceptions;
using AdAstra.Profiles;
using AdAstra.Services;
using AutoFixture.NUnit3;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdAstra.Tests
{
    public class PostServiceTests
    {
        private Mock<IBaseRepository<Trip>> _tripRepositoryMock;
        private Mock<IBaseRepository<Post>> _postRepositoryMock;

        private PostService _postService;

        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            _mapper = mappingConfig.CreateMapper();

            _tripRepositoryMock = new Mock<IBaseRepository<Trip>>();
            _postRepositoryMock = new Mock<IBaseRepository<Post>>();
            _postService = new PostService(_mapper, _postRepositoryMock.Object, _tripRepositoryMock.Object);
        }

        [Test, AutoData]
        public void GetByIdAsync_NoPostsMatchingId_ThrowsException(int tripId, int postId)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip 
            { 
                Posts = new List<Post> 
                { 
                    new Post
                    {
                        Id = -1
                    }
                }
            });
            Func<Task> testDelegate = async () => await _postService.GetByIdAsync(tripId, postId);


            Assert.That(testDelegate, Throws.TypeOf<EntityMissingInDatabaseException>());
            _postRepositoryMock.Verify(x => x.GetByIdAsync(postId), Times.Never);
        }

        [Test, AutoData]
        public async Task GetByIdAsync_ValidData_CorrectlyReturns(int tripId, int postId)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip
            {
                Posts = new List<Post>
                {
                    new Post
                    {
                        Id = postId
                    }
                }
            });
            var actual = await _postService.GetByIdAsync(tripId, postId);

            Assert.That(actual.Id == postId);
        }

        [Test, AutoData]
        public void AddAsync_UserWithDifferentId_ThrowsForbiddenException(int tripId, string userId, PostPostDto post)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = "test" });

            Func<Task> testDelegate = async () => await _postService.AddAsync(tripId, userId, post);

            Assert.That(testDelegate, Throws.TypeOf<ForbiddenException>());
            _postRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Post>()), Times.Never);
        }

        [Test, AutoData]
        public async Task AddAsync_ValidData_CallsRepositoryMethod(int tripId, string userId, PostPostDto post)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip 
            { 
                ApplicationUserId = userId,
                Posts = new List<Post>
                {
                    new Post()
                }
            });

            await _postService.AddAsync(tripId, userId, post);

            _postRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Post>()), Times.Once);
        }

        [Test, AutoData]
        public void UpdateAsync_UserWithDifferentId_ThrowsForbiddenException(int tripId, int postId, string userId, PostPostDto post)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = "test" });

            Func<Task> testDelegate = async () => await _postService.UpdateAsync(tripId, postId, userId, post);

            Assert.That(testDelegate, Throws.TypeOf<ForbiddenException>());
            _postRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Post>()), Times.Never);
        }

        [Test, AutoData]
        public void UpdateAsync_NoPostsMatchingId_ThrowsException(int tripId, int postId, string userId, PostPostDto post)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip
            {
                ApplicationUserId = userId,
                Posts = new List<Post>
                {
                    new Post
                    {
                        Id = -1
                    }
                }
            });

            Func<Task> testDelegate = async () => await _postService.UpdateAsync(tripId, postId, userId, post);

            Assert.That(testDelegate, Throws.TypeOf<EntityMissingInDatabaseException>());
            _postRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Post>()), Times.Never);
        }

        [Test, AutoData]
        public async Task UpdateAsync_ValidData_CallsRepositoryMethod(int tripId, int postId, string userId, PostPostDto post)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip
            {
                ApplicationUserId = userId,
                Posts = new List<Post>
                {
                    new Post
                    {
                        Id = postId
                    }
                }
            });

            await _postService.UpdateAsync(tripId, postId, userId, post);

            _postRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Post>()), Times.Once);
        }

        [Test, AutoData]
        public void DeleteAsync_UserWithDifferentId_ThrowsForbiddenException(int tripId, int postId, string userId)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = "test" });

            Func<Task> testDelegate = async () => await _postService.DeleteAsync(tripId, postId, userId);

            Assert.That(testDelegate, Throws.TypeOf<ForbiddenException>());
            _postRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Post>()), Times.Never);
        }

        [Test, AutoData]
        public void DeleteAsync_NoPostsMatchingId_ThrowsException(int tripId, int postId, string userId)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip
            {
                ApplicationUserId = userId,
                Posts = new List<Post>
                {
                    new Post
                    {
                        Id = -1
                    }
                }
            });

            Func<Task> testDelegate = async () => await _postService.DeleteAsync(tripId, postId, userId);

            Assert.That(testDelegate, Throws.TypeOf<EntityMissingInDatabaseException>());
            _postRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Post>()), Times.Never);
        }


        //[Test, AutoData]
        //public void DeleteAsync_UserWithDifferentId_ThrowsForbiddenException(int tripId, string userId)
        //{
        //    _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = "test" });

        //    Func<Task> testDelegate = async () => await _tripService.DeleteAsync(tripId, userId);

        //    Assert.That(testDelegate, Throws.TypeOf<ForbiddenException>());
        //    _tripRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Trip>()), Times.Never);
        //}

        //[Test, AutoData]
        //public async Task DeleteAsync_ValidData_CalledRepositoryMethod(int tripId, string userId)
        //{
        //    _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = userId });

        //    await _tripService.DeleteAsync(tripId, userId);

        //    _tripRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Trip>()), Times.Once);
        //}

        //[Test, AutoData]
        //public void DeleteAsync_TripHasRelatedEntities_ThrowsCascadeDeleteRestrictedException(int tripId, string userId, TripPostDto trip)
        //{
        //    _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = userId });
        //    _tripRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<Trip>())).ThrowsAsync(new InvalidOperationException());

        //    Func<Task> testDelegate = async () => await _tripService.DeleteAsync(tripId, userId);

        //    Assert.That(testDelegate, Throws.TypeOf<CascadeDeleteRestrictedException>());
        //    _tripRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Trip>()), Times.Once);
        //}
    }
}
