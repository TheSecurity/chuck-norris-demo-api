
using ChuckNorris.Api.Models;

namespace ChuckNorris.Api.Services;

public class JokeService
{
    private const string BaseUrl = "https://api.chucknorris.io/jokes/random";

    private readonly IHttpClientFactory _httpClientFactory;

    public JokeService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<JokeModel?> GetRandomJokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetFromJsonAsync<JokeApiModel>(BaseUrl);

        if (response is null)
        {
            return null;
        }

        return new JokeModel
        {
            Id = response.Id,
            Value = response.Value
        };
    }
}
