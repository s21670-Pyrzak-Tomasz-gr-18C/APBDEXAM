using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;
namespace exam.Configurations
{
	public class TeamConfuguration : IEntityTypeConfiguration<Team>
	{
		public void Configure(EntityTypeBuilder<Team> builder)
		{
			builder
				.HasKey(e => e.TeamID);
			builder
				.Property(e => e.TeamName)
				.HasMaxLength(50)
				.IsRequired();
			builder
				.Property(e => e.TeamDescription)
				.HasMaxLength(500)
				.IsRequired(false);
			builder
				.HasOne(e => e.Organization)
				.WithMany(e => e.Teamss)
				.HasForeignKey(e => e.OrganizationID);

			builder.HasData(
				new Team { TeamID = 1, TeamName = "TeamName1", TeamDescription = "Description1", OrganizationID = 1 },
				new Team { TeamID = 2, TeamName = "TeamName2", TeamDescription = "Description2", OrganizationID = 2 },
				new Team { TeamID = 3, TeamName = "TeamName3", TeamDescription = "Description3", OrganizationID = 3 },
				new Team { TeamID = 4, TeamName = "TeamName4", TeamDescription = "Description4", OrganizationID = 4 },
				new Team { TeamID = 5, TeamName = "TeamName5", TeamDescription = "Description5", OrganizationID = 5 }
			);
		}
	}
}
