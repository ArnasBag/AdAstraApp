using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AdAstra.IntegrationTests.TestAuth
{
    public class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public TestAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            var claims = new List<Claim> 
            { 
                new Claim("userId", "test"),
                new Claim(ClaimTypes.Role, "User")
            };

            // Extract User ID from the request headers if it exists,
            // otherwise use the default User ID from the options.
            //if (Context.Request.Headers.TryGetValue(UserId, out var userId))
            //{
            //    claims.Add(new Claim(ClaimTypes.NameIdentifier, userId[0]));
            //}
            //else
            //{
            //    claims.Add(new Claim(ClaimTypes.NameIdentifier, _defaultUserId));
            //}

            var identity = new ClaimsIdentity(claims, "Test");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Test");

            var result = AuthenticateResult.Success(ticket);

            return Task.FromResult(result);
        }
    }
}
