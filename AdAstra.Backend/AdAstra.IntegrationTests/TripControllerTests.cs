using AdAstra.DataAccess.Data;
using AdAstra.DataAccess.Entities;
using AdAstra.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Xunit;

namespace AdAstra.IntegrationTests
{
    public class TripControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly IServiceScope _scope;
        private readonly ApplicationDbContext _context;


        public TripControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;

            _scope = (factory.Services.GetRequiredService<IServiceScopeFactory>()).CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            // database is now shared across tests
            _context.Database.EnsureCreated();


            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }


        [Fact]
        public async void Test1()
        {
            var guid = Guid.NewGuid().ToString();

            var expectedDto = new List<TripViewDto>
            {
                new TripViewDto
                {
                    Id = 1,
                    Name = "test",
                    Description = "test",
                    StartDate = new System.DateTime(2022, 01, 01),
                    EndDate = new System.DateTime(2022, 01, 02),
                    UserEmail = "test@email.com",
                    Posts = new List<PostViewDto>()
                }
            };

            var expected = new List<Trip>
            {
                new Trip
                {
                    Name = "test",
                    Description = "test",
                    StartDate = new System.DateTime(2022, 01, 01),
                    EndDate = new System.DateTime(2022, 01, 02),
                    ApplicationUser = new ApplicationUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "test",
                        Email = "test@email.com"
                    }
                }
            };

            _context.Trips.Add(expected[0]) ;

            await _context.SaveChangesAsync();

            var response = await _client.GetAsync("api/trips");

            var tripsString = await response.Content.ReadAsStringAsync();
            var expectedString = JsonSerializer.Serialize(expectedDto, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            Assert.Equal(expectedString, tripsString);
        }
    }
}