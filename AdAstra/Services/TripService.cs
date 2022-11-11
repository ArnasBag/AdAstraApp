using AdAstra.DataAccess.Entities;
using AdAstra.DataAccess.Interfaces;
using AdAstra.Dtos;
using AdAstra.Exceptions;
using AdAstra.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdAstra.Services
{
    public class TripService : ITripService
    {
        private readonly IBaseRepository<Trip> _tripRepository;
        private readonly IMapper _mapper;

        public TripService(IBaseRepository<Trip> tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<List<TripViewDto>> GetAllAsync()
        {
            var trips = await _tripRepository.GetAll()
                .Include(t => t.Posts)
                .Include(t => t.ApplicationUser)
                .ToListAsync();

            var mapped = trips.Select(t =>
            {
                var mapped = _mapper.Map<TripViewDto>(t);
                mapped.UserEmail = t.ApplicationUser.Email;
                return mapped;
            });

            return mapped.ToList();
        }

        public async Task<TripViewDto> GetByIdAsync(int tripId)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            return _mapper.Map<TripViewDto>(trip);
        }

        public async Task<TripViewDto> AddAsync(string userId, TripPostDto tripDto)
        {
            var tripEntity = _mapper.Map<Trip>(tripDto);
            tripEntity.ApplicationUserId = userId;

            await _tripRepository.AddAsync(tripEntity);

            return _mapper.Map<TripViewDto>(tripEntity);
        }

        public async Task UpdateAsync(int tripId, string userId, TripPostDto tripDto)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            if(trip.ApplicationUserId != userId)
            {
                throw new ForbiddenException("You can only update your own trips!");
            }

            trip.Name = tripDto.Name;
            trip.Description = tripDto.Description;
            trip.StartDate = tripDto.StartDate;
            trip.EndDate = tripDto.EndDate;

            await _tripRepository.UpdateAsync(trip);
        }

        public async Task DeleteAsync(int tripId, string userId)
        {
            var trip = await _tripRepository.GetByIdAsync(tripId);

            if (trip.ApplicationUserId != userId)
            {
                throw new ForbiddenException("You can only delete your own trips!");
            }

            try
            {
                await _tripRepository.DeleteAsync(trip);
            }
            catch(InvalidOperationException ex)
            {
                throw new CascadeDeleteRestrictedException("Cannot delete trip because there are posts associated with it!");
            }
        }
    }
}
