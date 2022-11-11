using Microsoft.AspNetCore.Identity;

namespace AdAstra.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
