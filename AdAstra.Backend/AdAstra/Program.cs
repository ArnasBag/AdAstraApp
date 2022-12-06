using AdAstra.DataAccess.Data;
using AdAstra.DataAccess.Extensions;
using AdAstra.Extensions;
using AdAstra.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDataAccess(builder.Configuration);
builder.Services.ConfigureIdentity(builder.Configuration);
builder.Services.ConfigureDependencyInjection();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

//await SeedData();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();

async Task SeedData()
{
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetRequiredService<ApplicationDbSeeder>();
        await seeder.SeedAsync();
    }
}

public partial class Program { }