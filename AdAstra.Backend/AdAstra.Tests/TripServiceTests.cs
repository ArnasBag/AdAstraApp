using AdAstra.DataAccess.Entities;
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
using System.Threading.Tasks;

namespace AdAstra.Tests
{
    public class TripServiceTests
    {
        private Mock<IBaseRepository<Trip>> _tripRepositoryMock;
        private TripService _tripService;

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
            _tripService = new TripService(_tripRepositoryMock.Object, _mapper);
        }

        [Test, AutoData]
        public async Task GetByIdAsync_CallsRepositoryMethod(int id)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(new Trip());

            await _tripService.GetByIdAsync(id);

            _tripRepositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once);
        }

        [Test, AutoData]
        public async Task AddAsync_CallsRepositoryMethod(string userId, TripPostDto trip)
        {
            await _tripService.AddAsync(userId, trip);

            _tripRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Trip>()), Times.Once);
        }

        [Test, AutoData]
        public void UpdateAsync_UserWithDifferentId_ThrowsForbiddenException(int tripId, string userId, TripPostDto trip)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = "test" });

            Func<Task> testDelegate = async () => await _tripService.UpdateAsync(tripId, userId, trip);


            Assert.That(testDelegate, Throws.TypeOf<ForbiddenException>());
            _tripRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Trip>()), Times.Never);
        }


        [Test, AutoData]
        public async Task UpdateAsync_ValidData_CalledRepositoryMethod(int tripId, string userId, TripPostDto trip)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = userId });

            await _tripService.UpdateAsync(tripId, userId, trip);

            _tripRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Trip>()), Times.Once);
        }


        [Test, AutoData]
        public void DeleteAsync_UserWithDifferentId_ThrowsForbiddenException(int tripId, string userId)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = "test" });

            Func<Task> testDelegate = async () => await _tripService.DeleteAsync(tripId, userId);

            Assert.That(testDelegate, Throws.TypeOf<ForbiddenException>());
            _tripRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Trip>()), Times.Never);
        }

        [Test, AutoData]
        public async Task DeleteAsync_ValidData_CalledRepositoryMethod(int tripId, string userId)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = userId });

            await _tripService.DeleteAsync(tripId, userId);

            _tripRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Trip>()), Times.Once);
        }

        [Test, AutoData]
        public void DeleteAsync_TripHasRelatedEntities_ThrowsCascadeDeleteRestrictedException(int tripId, string userId, TripPostDto trip)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = userId });
            _tripRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<Trip>())).ThrowsAsync(new InvalidOperationException());

            Func<Task> testDelegate = async () => await _tripService.DeleteAsync(tripId, userId);

            Assert.That(testDelegate, Throws.TypeOf<CascadeDeleteRestrictedException>());
            _tripRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Trip>()), Times.Once);
        }
    }
}
