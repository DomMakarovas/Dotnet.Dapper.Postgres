namespace Web.Template.Api.Application.Features.Weather.Queries;

public sealed record GetWeatherForecastQuery : IRequest<IReadOnlyCollection<WeatherForecast>>;