FROM microsoft/aspnetcore:2.0-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1803 AS build
WORKDIR /src
COPY NetCoreServiceTemplate/NetCoreServiceTemplate.csproj NetCoreServiceTemplate/
RUN dotnet restore NetCoreServiceTemplate/NetCoreServiceTemplate.csproj
COPY . .
WORKDIR /src/NetCoreServiceTemplate
RUN dotnet build NetCoreServiceTemplate.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NetCoreServiceTemplate.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCoreServiceTemplate.dll"]
