using System.Numerics;

using exam.Configurations;

using Microsoft.EntityFrameworkCore;

namespace exam.Models
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext()
		{
		}

		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Team> Teams { get; set; }
		public DbSet<Membership> Memberships { get; set; }
		public DbSet<Organization> Organizations { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<File> Files { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new FileConfiguration());
			modelBuilder.ApplyConfiguration(new MembershipConfiguration());
			modelBuilder.ApplyConfiguration(new MemberConfiguration());
			modelBuilder.ApplyConfiguration(new TeamConfuguration());
			modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
		}
	}
}
