using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFData.EntityTypeConfigurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
	public void Configure(EntityTypeBuilder<Game> builder)
	{
		builder
			.HasKey(x => x.Id);
		builder
			.HasMany(x => x.Genres)
			.WithMany(x => x.Games);
	}
}