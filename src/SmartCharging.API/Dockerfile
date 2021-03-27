#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SmartCharging.API/SmartCharging.API.csproj", "src/SmartCharging.API/"]
RUN dotnet restore "src/SmartCharging.API/SmartCharging.API.csproj"
COPY . .
WORKDIR "/src/src/SmartCharging.API"
RUN dotnet build "SmartCharging.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartCharging.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartCharging.API.dll"]