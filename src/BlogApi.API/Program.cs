using BlogApi.Application.Interfaces;
using BlogApi.Application.Services;
using BlogApi.Domain.Interfaces;
using BlogApi.Infrastructure.Context;
using BlogApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // Necessário para Swagger funcionar corretamente
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection
var config = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(config["ConnectionStrings:Default"]));

// Dependency Injection
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();

var app = builder.Build();

// Swagger ativado somente em Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization(); // importante se você usa autenticação

app.MapControllers();

app.Run();
