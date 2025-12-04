using Microsoft.EntityFrameworkCore;
using personalbeauty.Models;
using personalbeauty.Services;

var builder = WebApplication.CreateBuilder(args);


// Repository（メモリ保持）
builder.Services.AddSingleton<InMemoryRepository>();

// Controller と Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS（開発用）
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:3000");
    });
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DevCors");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
