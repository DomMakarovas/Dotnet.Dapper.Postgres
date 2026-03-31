namespace Dotnet.Dapper.Postgres.Api.Controllers;

public class WeatherForecastController(IMediator mediator) : BaseApiController(mediator)
{
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken cancellationToken)
    {
        var forecasts = await Mediator.Send(new GetWeatherForecastQuery(), cancellationToken);
        return forecasts;
    }
}