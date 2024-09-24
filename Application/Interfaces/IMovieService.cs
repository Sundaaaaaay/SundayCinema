﻿using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<Movie?>> GetAllMoviesAsync();
    Task<Movie?> GetMovieByIdAsync(int movieId);
    Task<CreateMovieDto?> CreateMovieAsync(Movie movie);
    Task<Movie?> DeleteMovieAsync(int movieId);
}