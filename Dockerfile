# Етап 1: Збірка (використовуємо SDK образ для компіляції)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Копіюємо файл проекту і відновлюємо залежності
# Важливо: шлях Src/Kurs-db.csproj має відповідати вашій структурі
COPY ["Src/Kurs-db.csproj", "Src/"]
RUN dotnet restore "Src/Kurs-db.csproj"

# 2. Копіюємо решту файлів коду
COPY . .

# 3. Переходимо в папку з кодом і збираємо проект
WORKDIR "/src/Src"
RUN dotnet build "Kurs-db.csproj" -c Release -o /app/build

# 4. Публікуємо (створюємо фінальні .dll файли)
FROM build AS publish
RUN dotnet publish "Kurs-db.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Етап 2: Запуск (використовуємо легкий Runtime образ)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kurs-db.dll"]