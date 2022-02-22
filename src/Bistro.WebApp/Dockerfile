#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Bistro.WebApp/Bistro.WebApp.csproj", "src/Bistro.WebApp/"]
COPY ["src/Bistro.Common/Bistro.Common.csproj", "src/Bistro.Common/"]
RUN dotnet restore "src/Bistro.WebApp/Bistro.WebApp.csproj"
COPY . .
WORKDIR "/src/src/Bistro.WebApp"
RUN dotnet build "Bistro.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bistro.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bistro.WebApp.dll"]
