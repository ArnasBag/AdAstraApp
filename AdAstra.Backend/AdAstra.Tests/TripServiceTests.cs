using AdAstra.DataAccess.Entities;
using AdAstra.DataAccess.Interfaces;
using AdAstra.Dtos;
using AdAstra.Profiles;
using AdAstra.Services;
using AutoFixture.NUnit3;
using AutoMapper;
using Moq;
using NUnit.Framework;
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
        public async Task UpdateAsync_CallsRepositoryMethod(int tripId, string userId, TripPostDto trip)
        {
            _tripRepositoryMock.Setup(x => x.GetByIdAsync(tripId)).ReturnsAsync(new Trip { ApplicationUserId = "test" })
            await _tripService.AddAsync(userId, trip);

            _tripRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Trip>()), Times.Once);
        }
    }
}
