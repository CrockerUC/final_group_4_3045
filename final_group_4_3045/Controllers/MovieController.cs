using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_group_4_3045.Models;
using final_group_4_3045.Data;
using final_group_4_3045.Interfaces;

namespace final_group_4_3045.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;
    private readonly IMovieContextDAO _movieDAO;

    public MovieController(
        ILogger<MovieController> logger,
        IMovieContextDAO movieDAO)
    {
        _logger = logger;
        _movieDAO = movieDAO;
    }

    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetMovies()
    {
        _logger.LogInformation("Getting all movies.");
        var movies = await _movieDAO.GetAllMoviesAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        _logger.LogInformation("Getting movie with ID {Id}.", id);
        var movie = await _movieDAO.GetMovieByIdAsync(id);
        if (movie == null)
        {
            _logger.LogWarning("Movie with ID {Id} was not found.", id);
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
    {
        _logger.LogInformation("Creating a new movie.");
        await _movieDAO.AddMovieAsync(movie);
        return CreatedAtAction(
            nameof(GetMovie),
            new { id = movie.Id },
            movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, Movie movie)
    {
        _logger.LogInformation("Updating movie with ID {Id}.", id);
        var existingMovie = await _movieDAO.GetMovieByIdAsync(id);
        if (existingMovie == null)
        {
            _logger.LogWarning("Movie with ID {Id} was not found for update.", id);
            return NotFound();
        }
        movie.Id = id;
        await _movieDAO.UpdateMovieAsync(movie);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        _logger.LogInformation("Deleting movie with ID {Id}.", id);
        var existingMovie = await _movieDAO.GetMovieByIdAsync(id);
        if (existingMovie == null)
        {
            _logger.LogWarning("Movie with ID {Id} was not found for deletion.", id);
            return NotFound();
        }
        if(string.IsNullOrEmpty(existingMovie.Title))
        {
            _logger.LogWarning("Movie with ID {Id} has no title.", id);
            return StatusCode(500, "An error occurred while processing your request");
        }
        await _movieDAO.DeleteMovieAsync(id);
        return NoContent();
    }
}