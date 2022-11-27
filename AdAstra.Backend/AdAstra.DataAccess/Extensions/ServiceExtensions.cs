using AdAstra.DataAccess.Data;
using AdAstra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using AdAstra.DataAccess.Entities;
using AdAstra.DataAccess.Interfaces;

namespace AdAstra.DataAccess.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddTransient<IBaseRepository<Trip>, TripRepository>();
            services.AddTransient<IBaseRepository<Post>, PostRepository>();
            services.AddTransient<IBaseRepository<Comment>, CommentRepository>();
        }
    }
}
