using Kurs_db.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. ПІДКЛЮЧЕННЯ ДО БАЗИ (Бере рядок з appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<Kurs_db.Services.OrderService>();

// 2. Додаємо контролери
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Це щоб не було помилок при циклах (коли клієнт посилається на замовлення, а замовлення на клієнта)
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// 3. Сваггер (документація API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Налаштування HTTP пайплайну
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();