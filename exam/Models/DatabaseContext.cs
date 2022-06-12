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

		public DbSet<Musician> Musicians { get; set; }
		public DbSet<MusicianTrack> MusicianTracks { get; set; }
		public DbSet<Track> Tracks { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<MusicLabel> MusicLabels { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new MusicianConfiguration());
			modelBuilder.ApplyConfiguration(new MusicianTrackConfiguration());
			modelBuilder.ApplyConfiguration(new TrackConfiguration());
			modelBuilder.ApplyConfiguration(new AlbumConfuguration());
			modelBuilder.ApplyConfiguration(new MusicLabelConfiguration());
		}
	}
}
