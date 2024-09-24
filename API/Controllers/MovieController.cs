using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SundayCinema.Presentation.Controllers;

[Route("sundaycinema/movies")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMovies()
    {
        return Ok(await _movieService.GetAllMoviesAsync());
    }
}