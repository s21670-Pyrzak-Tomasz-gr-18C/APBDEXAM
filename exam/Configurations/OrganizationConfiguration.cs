using exam.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Numerics;
namespace exam.Configurations
{
	public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
	{
		public void Configure(EntityTypeBuilder<Organization> builder)
		{
			builder
				.HasKey(e => e.OrganizationID);
			builder
				.Property(e => e.OrganizationName)
				.HasMaxLength(100)
				.IsRequired();
			builder
				.Property(e => e.OrganizationDomain)
				.HasMaxLength(50)
				.IsRequired();

			builder.HasData(
				new Organization { OrganizationID = 1, OrganizationName = "Name1", OrganizationDomain = "Domain1"},
				new Organization { OrganizationID = 2, OrganizationName = "Name2", OrganizationDomain = "Domain1"},
				new Organization { OrganizationID = 3, OrganizationName = "Name3", OrganizationDomain = "Domain2"},
				new Organization { OrganizationID = 4, OrganizationName = "Name4", OrganizationDomain = "Domain4"},
				new Organization { OrganizationID = 5, OrganizationName = "Name5", OrganizationDomain = "Domain5"}
			);
		}
	}
}
