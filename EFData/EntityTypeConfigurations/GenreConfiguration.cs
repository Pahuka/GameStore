using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFData.EntityTypeConfigurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
	public void Configure(EntityTypeBuilder<Genre> builder)
	{
		builder
			.HasKey(x => x.Id);
		builder
			.HasMany(x => x.Games)
			.WithMany(x => x.Genres);
	}
}