using AdAstra.Dtos;
using AdAstra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdAstra.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        private readonly IAuthorizationService _authorizationService;

        public TripController(ITripService tripService, IAuthorizationService authorizationService)
        {
            _tripService = tripService;
            _authorizationService = authorizationService;
        }

        [HttpGet("trips")]
        public async Task<IActionResult> GetAllTrips()
        {
            var trips = await _tripService.GetAllAsync();

            return Ok(trips);
        }

        [HttpGet("trips/{tripId}")]
        public async Task<IActionResult> GetTripById(int tripId)
        {
            var trip = await _tripService.GetByIdAsync(tripId);

            return Ok(trip);
        }

        [Authorize(AuthenticationSchemes = "Test")]
        [HttpPost("trips")]
        public async Task<IActionResult> AddTrip(TripPostDto request)
        {
            var trip = await _tripService.AddAsync(User.FindFirst("userId").Value, request);

            return CreatedAtAction(nameof(GetTripById), new { tripId = trip.Id }, trip);
        }

        [Authorize(Roles = "User")]
        [HttpPut("trips/{tripId}")]
        public async Task<IActionResult> UpdateTrip(TripPostDto request, int tripId)
        {
            await _tripService.UpdateAsync(tripId, User.FindFirst("userId").Value, request);

            return NoContent();       
        }

        [Authorize(Roles = "User")]
        [HttpDelete("trips/{tripId}")]
        public async Task<IActionResult> DeleteTrip(int tripId)
        {
            await _tripService.DeleteAsync(tripId, User.FindFirst("userId").Value);

            return NoContent();
        }

    }
}
