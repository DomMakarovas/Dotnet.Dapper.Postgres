namespace Dotnet.Dapper.Postgres.Api.Controllers.Abstractions;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}