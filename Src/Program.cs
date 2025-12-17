using Kurs_db.Models;
using Kurs_db.Services; // ОБОВ'ЯЗКОВО: Додати цей using, щоб бачити сервіси
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. ПІДКЛЮЧЕННЯ ДО БАЗИ (Бере рядок з appsettings.json або змінних оточення)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseNpgsql(connectionString));

// =========================================================
// 2. РЕЄСТРАЦІЯ СЕРВІСІВ (Це те, чого не вистачало!)
// =========================================================
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AnalyticsService>();
// =========================================================

// 3. Додаємо контролери
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Це щоб не було помилок при циклах (коли клієнт посилається на замовлення, а замовлення на клієнта)
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// 4. Сваггер (документація API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Налаштування HTTP пайплайну
// Вмикаємо Swagger навіть якщо не Development, щоб ви могли показати його викладачу
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();