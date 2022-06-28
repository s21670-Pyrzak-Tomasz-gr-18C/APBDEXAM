using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;
namespace exam.Configurations
{
	public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
	{
		public void Configure(EntityTypeBuilder<Membership> builder)
		{
			builder
				.HasKey(e => new
				{
					e.MemberID,
					e.TeamID
				});
			builder
				.HasOne(e => e.Member)
				.WithMany(e => e.Memberships)
				.HasForeignKey(e => e.MemberID);
			builder
				.HasOne(e => e.Team)
				.WithMany(e => e.Memberships)
				.HasForeignKey(e => e.TeamID);
			builder
				.Property(e => e.MembershipDate)
				.IsRequired();
			builder.HasData(
				new Membership { MemberID = 1, TeamID = 1, MembershipDate = Convert.ToDateTime("2022-01-01") },
				new Membership { MemberID = 2, TeamID = 2, MembershipDate = Convert.ToDateTime("2022-01-01") },
				new Membership { MemberID = 3, TeamID = 3, MembershipDate = Convert.ToDateTime("2022-01-01") },
				new Membership { MemberID = 4, TeamID = 4, MembershipDate = Convert.ToDateTime("2022-01-01") },
				new Membership { MemberID = 5, TeamID = 5, MembershipDate = Convert.ToDateTime("2022-01-01") }
			);
		}
	}
}
