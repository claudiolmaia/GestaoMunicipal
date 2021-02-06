#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PPGM.Autenticacao.API.csproj", "src/services/PPGM.Autenticacao.API/"]
COPY ["src/bulding-blocks/PPGM.Core/PPGM.Core.csproj", "src/bulding-blocks/PPGM.Core/"]
COPY ["src/bulding-blocks/PPGM.MessageBus/PPGM.MessageBus.csproj", "src/bulding-blocks/PPGM.MessageBus/"]
COPY ["src/bulding-blocks/PPGM.WebAPI.Core/PPGM.WebAPI.Core.csproj", "src/bulding-blocks/PPGM.WebAPI.Core/"]
RUN dotnet restore "src/services/PPGM.Autenticacao.API/PPGM.Autenticacao.API.csproj"
COPY . .
WORKDIR "/src/src/services/PPGM.Autenticacao.API"
RUN dotnet build "PPGM.Autenticacao.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PPGM.Autenticacao.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PPGM.Autenticacao.API.dll"]