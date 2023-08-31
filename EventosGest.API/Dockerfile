#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EventosGest.API/EventosGest.API.csproj", "EventosGest.API/"]
RUN dotnet restore "EventosGest.API/EventosGest.API.csproj"
COPY . .
WORKDIR "/src/EventosGest.API"
RUN dotnet build "EventosGest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventosGest.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventosGest.API.dll"]