FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Src/Kurs-db.csproj", "Src/"]
RUN dotnet restore "Src/Kurs-db.csproj"

COPY . .

WORKDIR "/src/Src"
RUN dotnet build "Kurs-db.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kurs-db.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kurs-db.dll"]