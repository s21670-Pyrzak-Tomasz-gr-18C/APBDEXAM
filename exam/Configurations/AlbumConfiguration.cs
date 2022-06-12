using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;
namespace exam.Configurations
{
	public class AlbumConfuguration : IEntityTypeConfiguration<Album>
	{
		public void Configure(EntityTypeBuilder<Album> builder)
		{
			builder
				.HasKey(e => e.IdAlbum);
			builder
				.Property(e => e.AlbumName)
				.HasMaxLength(30)
				.IsRequired();
			builder
				.Property(e => e.PublishDate)
				.IsRequired();
			builder
				.HasOne(e => e.MusicLabel)
				.WithMany(e => e.Albums)
				.HasForeignKey(e => e.IdMusicLabel);

			builder.HasData(
				new Album { IdAlbum = 1, AlbumName = "AlbumName1", PublishDate = Convert.ToDateTime("2022-01-01"), IdMusicLabel = 1 },
				new Album { IdAlbum = 2, AlbumName = "AlbumName2", PublishDate = Convert.ToDateTime("2022-01-01"), IdMusicLabel = 1 },
				new Album { IdAlbum = 3, AlbumName = "AlbumName3", PublishDate = Convert.ToDateTime("2022-01-01"), IdMusicLabel = 1 },
				new Album { IdAlbum = 4, AlbumName = "AlbumName4", PublishDate = Convert.ToDateTime("2022-01-01"), IdMusicLabel = 1 },
				new Album { IdAlbum = 5, AlbumName = "AlbumName5", PublishDate = Convert.ToDateTime("2022-01-01"), IdMusicLabel = 1 }
			);
		}
	}
}
