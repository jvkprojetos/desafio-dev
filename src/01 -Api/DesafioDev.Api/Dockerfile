FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /src
COPY ["src/01 -Api/DesafioDev.Api/DesafioDev.Api.csproj", "src/01 -Api/DesafioDev.Api/"]
COPY ["src/02 - Application/DesafioDev.Application/DesafioDev.Application.csproj", "src/02 - Application/DesafioDev.Application/"]
COPY ["src/03 - Domain/DesafioDev.Domain/DesafioDev.Domain.csproj", "src/03 - Domain/DesafioDev.Domain/"]
COPY ["src/04 - Infra/DesafioDev.Infra.Persistence/DesafioDev.Infra.Persistence.csproj", "src/04 - Infra/DesafioDev.Infra.Persistence/"]
RUN dotnet restore "src/01 -Api/DesafioDev.Api/DesafioDev.Api.csproj"
COPY . .
WORKDIR "/src/src/01 -Api/DesafioDev.Api"
RUN dotnet build "DesafioDev.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioDev.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioDev.Api.dll"]