using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;

namespace exam.Configurations
{
	public class MusicianConfiguration : IEntityTypeConfiguration<Musician>
	{
		public void Configure(EntityTypeBuilder<Musician> builder)
		{
			builder
				.HasKey(e => e.IdMusician);
			builder
				.Property(e => e.FirstName)
				.HasMaxLength(30)
				.IsRequired();
			builder
				.Property(e => e.LastName)
				.HasMaxLength(50)
				.IsRequired();
			builder
				.Property(e => e.Nickname)
				.HasMaxLength(20)
				.IsRequired(false);

			builder.HasData(
				new Musician{ IdMusician = 1, FirstName = "FirstName1", LastName = "LastName1", Nickname = "Nickname1" },
				new Musician{ IdMusician = 2, FirstName = "FirstName2", LastName = "LastName2", Nickname = "Nickname2" },
				new Musician{ IdMusician = 3, FirstName = "FirstName3", LastName = "LastName3", Nickname = "Nickname3" },
				new Musician{ IdMusician = 4, FirstName = "FirstName4", LastName = "LastName4", Nickname = "Nickname4" },
				new Musician{ IdMusician = 5, FirstName = "FirstName5", LastName = "LastName5", Nickname = "Nickname5" }
			);
		}
	}
}
