#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CryptoAPI/CryptoAPI.csproj", "CryptoAPI/"]
RUN dotnet restore "CryptoAPI/CryptoAPI.csproj"
COPY . .
WORKDIR "/src/CryptoAPI"
RUN dotnet build "CryptoAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CryptoAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CryptoAPI.dll"]
