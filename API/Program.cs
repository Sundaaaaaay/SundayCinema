using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Services;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repositories;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Dependency injection for application services and repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddHostedService<CleanUpSessionService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IMovieService, MovieService>();

// Configure the application's database context with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLogWeb();
});

var app = builder.Build();

// Configure middleware for development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();