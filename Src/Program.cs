using Kurs_db.Models;
using Kurs_db.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AnalyticsService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();