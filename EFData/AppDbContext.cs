using Domain.Entities;
using EFData.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EFData;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
		Database.EnsureCreated();
	}

	public DbSet<Game> Games { get; set; }
	public DbSet<Genre> Genres { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new GameConfiguration());
		modelBuilder.ApplyConfiguration(new GenreConfiguration());
		base.OnModelCreating(modelBuilder);
	}
}