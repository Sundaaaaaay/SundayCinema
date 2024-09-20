using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<CinemaHall> CinemaHalls { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CinemaHall>()
            .HasMany(ch => ch.Sessions)
            .WithOne(s => s.CinemaHall)
            .HasForeignKey(s => s.CinemaHallId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<CinemaHall>()
            .HasMany(ch => ch.Seats)
            .WithOne(s => s.CinemaHall)
            .HasForeignKey(s => s.CinemaHallId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Session>()
            .HasMany(s => s.Tickets)
            .WithOne(s => s.Session)
            .HasForeignKey(s => s.SessionId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Sessions)
            .WithOne(s => s.Movie)
            .HasForeignKey(s => s.MovieId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Seat>()
            .HasOne(s => s.CinemaHall)
            .WithMany(s => s.Seats)
            .HasForeignKey(s => s.CinemaHallId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Ticket>()
            .HasOne(s => s.Session)
            .WithMany(s => s.Tickets)
            .HasForeignKey(s => s.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}