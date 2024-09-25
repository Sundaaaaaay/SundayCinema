﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _context;

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Movie?>> GetAllMoviesAsync()
    {
        var movies = _context.Movies.ToList();
        
        return movies;
    }

    public async Task<Movie?> GetMovieByIdAsync(int movieId)
    {
        throw new NotImplementedException();
    }

    public async Task<Movie?> CreateMovieAsync(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        
        return movie;
    }

    public async Task<Movie?> DeleteMovieAsync(int movieId)
    {
        throw new NotImplementedException();
    }
}