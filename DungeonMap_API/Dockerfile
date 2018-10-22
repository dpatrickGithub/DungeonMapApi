FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 51133
EXPOSE 44383

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DungeonMap_API/DungeonMap_API.csproj", "DungeonMap_API/"]
RUN dotnet restore "DungeonMap_API/DungeonMap_API.csproj"
COPY . .
WORKDIR "/src/DungeonMap_API"
RUN dotnet build "DungeonMap_API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DungeonMap_API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DungeonMap_API.dll"]