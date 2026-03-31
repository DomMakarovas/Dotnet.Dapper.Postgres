namespace Web.Template.Api.Application.Features.Weather.Handlers;

public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IReadOnlyCollection<WeatherForecast>>
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public Task<IReadOnlyCollection<WeatherForecast>> Handle(
        GetWeatherForecastQuery request,
        CancellationToken cancellationToken)
    {
        var result = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        return Task.FromResult<IReadOnlyCollection<WeatherForecast>>(result);
    }
}