using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;
namespace exam.Configurations
{
	public class MusicLabelConfiguration : IEntityTypeConfiguration<MusicLabel>
	{
		public void Configure(EntityTypeBuilder<MusicLabel> builder)
		{
			builder
				.HasKey(e => e.IdMusicLabel);
			builder
				.Property(e => e.Name)
				.HasMaxLength(50)
				.IsRequired();

			builder.HasData(
				new MusicLabel { IdMusicLabel = 1, Name = "MusicLabel1" },
				new MusicLabel { IdMusicLabel = 2, Name = "MusicLabel2" },
				new MusicLabel { IdMusicLabel = 3, Name = "MusicLabel3" },
				new MusicLabel { IdMusicLabel = 4, Name = "MusicLabel4" },
				new MusicLabel { IdMusicLabel = 5, Name = "MusicLabel5" }
			);
		}
	}
}
