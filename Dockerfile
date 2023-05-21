#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV PORT 5236
EXPOSE 5236

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/WebApi/WebApi.csproj", "Presentation/WebApi/"]
COPY ["Core/Application/Application.csproj", "Core/Application/"]
COPY ["Core/Domain/Domain.csproj", "Core/Domain/"]
COPY ["Infrastructure/Persistence/Persistence.csproj", "Infrastructure/Persistence/"]
RUN dotnet restore "Presentation/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]