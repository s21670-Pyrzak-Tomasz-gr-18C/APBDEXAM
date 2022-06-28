using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;

namespace exam.Configurations
{
	public class FileConfiguration : IEntityTypeConfiguration<File>
	{
		public void Configure(EntityTypeBuilder<File> builder)
		{
			builder.HasKey(e => new
			{
				e.FileID,
				e.TeamID
			});
			builder
				.Property(e => e.FileName)
				.HasMaxLength(100)
				.IsRequired();
			builder
				.Property(e => e.FileExtension)
				.HasMaxLength(4)
				.IsRequired();
			builder
				.Property(e => e.FileSize)
				.IsRequired();
			builder
				.HasOne(e => e.Team)
				.WithMany(e => e.Files);
			builder.HasData(
				new File { FileID = 1, TeamID = 1, FileName = "FiletName1", FileExtension = "Extension1", FileSize = 1 },
				new File { FileID = 2, TeamID = 1, FileName = "FiletName2", FileExtension = "Extension2", FileSize = 2 },
				new File { FileID = 3, TeamID = 1, FileName = "FiletName3", FileExtension = "Extension3", FileSize = 3 },
				new File { FileID = 4, TeamID = 1, FileName = "FiletName4", FileExtension = "Extension4", FileSize = 4 },
				new File { FileID = 5, TeamID = 1, FileName = "FiletName5", FileExtension = "Extension5", FileSize = 5 }
			);
		}
	}
}
