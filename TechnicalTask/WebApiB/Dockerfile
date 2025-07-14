FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApiB/WebApiB.csproj", "WebApiB/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "WebApiB/WebApiB.csproj" --disable-parallel
COPY ["WebApiB/", "WebApiB/"]
COPY ["Models/", "Models/"]
WORKDIR "/src/WebApiB"
RUN dotnet build "WebApiB.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApiB.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiB.dll"]