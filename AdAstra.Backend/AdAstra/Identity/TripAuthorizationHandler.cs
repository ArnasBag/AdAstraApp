using Microsoft.AspNetCore.Authorization;

namespace AdAstra.Identity
{
    public class TripAuthorizationHandler : IAuthorizationHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TripAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var value = _httpContextAccessor.HttpContext.Request.Query;
            return Task.CompletedTask;
        }
    }
    public class SameUserRequirement : IAuthorizationRequirement{}
}
