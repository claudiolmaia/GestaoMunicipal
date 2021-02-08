#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./services-municipio/PPGM.STUR.API/PPGM.STUR.API.csproj", "services-municipio/PPGM.STUR.API/"]
COPY ["./bulding-blocks/PPGM.Core/PPGM.Core.csproj", "bulding-blocks/PPGM.Core/"]
COPY ["./bulding-blocks/PPGM.MessageBus/PPGM.MessageBus.csproj", "bulding-blocks/PPGM.MessageBus/"]
COPY ["./bulding-blocks/PPGM.WebAPI.Core/PPGM.WebAPI.Core.csproj", "bulding-blocks/PPGM.WebAPI.Core/"]
RUN dotnet restore "services-municipio/PPGM.STUR.API/PPGM.STUR.API.csproj"
COPY . .
WORKDIR "services-municipio/PPGM.STUR.API"
RUN dotnet build "PPGM.STUR.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PPGM.STUR.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PPGM.STUR.API.dll"]