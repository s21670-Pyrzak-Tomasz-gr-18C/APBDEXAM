using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;
namespace exam.Configurations
{
	public class MusicianTrackConfiguration : IEntityTypeConfiguration<MusicianTrack>
	{
		public void Configure(EntityTypeBuilder<MusicianTrack> builder)
		{
			builder
				.HasKey(e => new
				{
					e.IdTrack,
					e.IdMusician
				});
			builder
				.HasOne(e => e.Track)
				.WithMany(e => e.MusicianTracks)
				.HasForeignKey(e => e.IdTrack);
			builder
				.HasOne(e => e.Musician)
				.WithMany(e => e.MusicTracks)
				.HasForeignKey(e => e.IdMusician);

			builder.HasData(
				new MusicianTrack { IdTrack = 1, IdMusician = 1 },
				new MusicianTrack { IdTrack = 2, IdMusician = 1 },
				new MusicianTrack { IdTrack = 3, IdMusician = 1 },
				new MusicianTrack { IdTrack = 4, IdMusician = 2 },
				new MusicianTrack { IdTrack = 5, IdMusician = 3 }
			);
		}
	}
}
