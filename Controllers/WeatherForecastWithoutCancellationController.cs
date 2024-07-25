using Microsoft.AspNetCore.Mvc;

namespace cancellationToken.Controllers;

[ApiController]
[Route("WeatherForecastWithoutCancellation")]
public class WeatherForecastWithoutCancellationController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastWithoutCancellationController> _logger;

    public WeatherForecastWithoutCancellationController(ILogger<WeatherForecastWithoutCancellationController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<WeatherForecast>> Get()
    {
        return await GetDataAsync();
    }

    private async Task<IReadOnlyCollection<WeatherForecast>> GetDataAsync()
    {
        var weatherForecasts = Array.Empty<WeatherForecast>();
        try
        {
            for (var i = 0; i < 5; i++)
            {
                await Task.Delay(500);
                var weatherForecast = new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
                _logger.LogInformation($"Date: {weatherForecast.Date}, Temperature: {weatherForecast.TemperatureC}, Summary: {weatherForecast.Summary}");
                weatherForecasts.Append(weatherForecast);
            }
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogError("catch OperationCanceledException");
            _logger.LogError(ex.Message);
        }
        return weatherForecasts;
    }
}
