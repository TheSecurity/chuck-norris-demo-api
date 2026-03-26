using ChuckNorris.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChuckNorris.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class JokesController : ControllerBase
{
    private readonly JokeService _jokeService;
    private readonly ILogger<JokesController> _logger;

    public JokesController(JokeService jokeService, ILogger<JokesController> logger)
    {
        _jokeService = jokeService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Received request for a random joke.");
        var joke = await _jokeService.GetRandomJokeAsync();

        if (joke == null)
        {
            return NotFound();
        }

        if (Random.Shared.Next(0, 5) < 1)
        {
            _logger.LogWarning("A warning occurred while fetching the joke.");
            return StatusCode(503, "Service is temporarily unavailable. Please try again later.");
        }

        if (Random.Shared.Next(0, 5) < 3) // Simulate a random error with a 60% chance
        {
            _logger.LogError("An error occurred while fetching the joke.");
            return StatusCode(500, "An error occurred while fetching the joke.");
        }

        return Ok(joke);
    }
}
