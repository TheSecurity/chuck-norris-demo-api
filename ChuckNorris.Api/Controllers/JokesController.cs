using ChuckNorris.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChuckNorris.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class JokesController : ControllerBase
{
    private readonly JokeService _jokeService;

    public JokesController(JokeService jokeService)
    {
        _jokeService = jokeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var joke = await _jokeService.GetRandomJokeAsync();

        if (joke == null)
        {
            return NotFound();
        }

        return Ok(joke);
    }
}
