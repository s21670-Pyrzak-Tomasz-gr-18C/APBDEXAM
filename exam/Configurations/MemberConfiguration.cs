using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;
namespace exam.Configurations
{
	public class MemberConfiguration : IEntityTypeConfiguration<Member>
	{
		public void Configure(EntityTypeBuilder<Member> builder)
		{
			builder
				.HasKey(e => e.MemberID);
			builder
				.Property(e => e.MemberName)
				.HasMaxLength(20)
				.IsRequired();
			builder
				.Property(e => e.MemberSurname)
				.HasMaxLength(50)
				.IsRequired();
			builder
				.Property(e => e.MemberNickName)
				.HasMaxLength(20)
				.IsRequired(false);
			builder
				.HasOne(e => e.Organization)
				.WithMany(e => e.Members)
				.HasForeignKey(e => e.OrganizationID)
				.IsRequired(false);

			builder.HasData(
				new Member { MemberID = 1, MemberName = "Member1", MemberSurname = "Surname1", MemberNickName = "Nick1", OrganizationID = 1 },
				new Member { MemberID = 2, MemberName = "Member2", MemberSurname = "Surname2", MemberNickName = "Nick2", OrganizationID = 2 },
				new Member { MemberID = 3, MemberName = "Member3", MemberSurname = "Surname3", MemberNickName = "Nick3", OrganizationID = 3 },
				new Member { MemberID = 4, MemberName = "Member4", MemberSurname = "Surname4", MemberNickName = "Nick4", OrganizationID = 4 },
				new Member { MemberID = 5, MemberName = "Member5", MemberSurname = "Surname5", MemberNickName = "Nick5", OrganizationID = 5 }
			);
		}
	}
}
