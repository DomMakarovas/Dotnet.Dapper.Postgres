FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Dotnet.Dapper.Postgres.Api/Dotnet.Dapper.Postgres.Api.csproj", "Dotnet.Dapper.Postgres.Api/"]
COPY ["Dotnet.Dapper.Postgres.Application/Dotnet.Dapper.Postgres.Application.csproj", "Dotnet.Dapper.Postgres.Application/"]
RUN dotnet restore "Dotnet.Dapper.Postgres.Api/Dotnet.Dapper.Postgres.Api.csproj"
COPY . .
WORKDIR "/src/Dotnet.Dapper.Postgres.Api"
RUN dotnet build "./Dotnet.Dapper.Postgres.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Dotnet.Dapper.Postgres.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet.Dapper.Postgres.Api.dll"]
