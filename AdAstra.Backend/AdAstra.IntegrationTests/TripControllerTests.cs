using AdAstra.DataAccess.Data;
using AdAstra.DataAccess.Entities;
using AdAstra.Dtos;
using AdAstra.IntegrationTests.TestAuth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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


            //_client = _factory.WithWebHostBuilder(builder =>
            //{
            //    builder.ConfigureTestServices(services =>
            //    {
            //        services.AddAuthentication("Test")
            //            .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
            //    });
            //}).CreateClient(new WebApplicationFactoryClientOptions
            //{
            //    AllowAutoRedirect = false,
            //});

            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }

        [Fact]
        public async void GetAllTrips_ReturnsCorrectDataFromDb()
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

        [Fact]
        public async void AddTrip_PostsDataCorrectly()
        {
            _context.Users.Add(new ApplicationUser
            {
                Id = "test",
                FirstName = "test"
            });

            await _context.SaveChangesAsync();

            var request = new TripPostDto
            {
                Name = "test1",
                Description = "test1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            var json = JsonSerializer.Serialize(request);

            var response = await _client.PostAsync("api/trips", new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var fromDb = await _client.GetAsync("api/trips/1");

            var jsonFromDb = await fromDb.Content.ReadAsStringAsync();

            var entity = JsonSerializer.Deserialize<TripViewDto>(jsonFromDb);

            Assert.Equal(entity.Name, request.Name);
            Assert.Equal(entity.Description, request.Description);
        }
    }
}