FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CSVReader/CSVReader.csproj", "CSVReader/"]
RUN dotnet restore "CSVReader/CSVReader.csproj"
COPY . .
WORKDIR "/src/CSVReader"
RUN dotnet build "CSVReader.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSVReader.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSVReader.dll"]
