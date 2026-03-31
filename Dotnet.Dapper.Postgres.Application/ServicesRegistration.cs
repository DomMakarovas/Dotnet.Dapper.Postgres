namespace Dotnet.Dapper.Postgres.Application;

public static class ServicesRegistration
{
    private sealed class MediatRTarget;
    
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(static config => config.RegisterServicesFromAssemblyContaining<MediatRTarget>());
    }
}