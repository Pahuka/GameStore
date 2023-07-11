using Application.Implementations;
using Application.Interfaces;
using EFData;
using EFData.Repository;
using GameStoreServices.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connetion = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connetion));
builder.Services.AddTransient<IGameViewModel, GameViewModel>();
builder.Services.AddTransient<IGenreViewModel, GenreViewModel>();
builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IGameRepository, GameRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();