using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;
namespace exam.Configurations
{
	public class TrackConfiguration : IEntityTypeConfiguration<Track>
	{
		public void Configure(EntityTypeBuilder<Track> builder)
		{
			builder
				.HasKey(e => e.IdTrack);
			builder
				.Property(e => e.TrackName)
				.HasMaxLength(20)
				.IsRequired();
			builder
				.Property(e => e.Duration)
				.IsRequired();
			builder
				.HasOne(e => e.Album)
				.WithMany(e => e.Tracks)
				.HasForeignKey(e => e.IdMusicAlbum)
				.IsRequired(false);

			builder.HasData(
				new Track { IdTrack = 1, TrackName = "Track1", Duration = 1, IdMusicAlbum = 1 },
				new Track { IdTrack = 2, TrackName = "Track2", Duration = 1, IdMusicAlbum = 2 },
				new Track { IdTrack = 3, TrackName = "Track3", Duration = 1, IdMusicAlbum = 3 },
				new Track { IdTrack = 4, TrackName = "Track4", Duration = 1, IdMusicAlbum = 4 },
				new Track { IdTrack = 5, TrackName = "Track5", Duration = 1, IdMusicAlbum = 5 }
			);
		}
	}
}
