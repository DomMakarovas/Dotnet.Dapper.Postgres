namespace Dotnet.Dapper.Postgres.Application.Features.Weather.Queries;

public sealed record GetWeatherForecastQuery : IRequest<IReadOnlyCollection<WeatherForecast>>;