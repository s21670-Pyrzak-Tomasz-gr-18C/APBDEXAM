using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

using exam.Models;
using exam.Models.DTO;

using Microsoft.EntityFrameworkCore;

namespace exam.Services
{
	public class MusicianDatabaseService : IMusicianDatabaseService
	{
		private readonly DatabaseContext _databaseContext;

		public MusicianDatabaseService(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<AlbumDto> GetMusicianAsync(int idAlbum)
		{
			using (var Transaction = await _databaseContext.Database.BeginTransactionAsync())
			{
				return await _databaseContext.Albums
				.Where(album => album.IdAlbum == idAlbum)
				.Select(album => new AlbumDto
				{
					AlbumName = album.AlbumName,
					PublishDate = album.PublishDate,
					IdMusicLabel = album.IdMusicLabel,
					MusicLabel = album.MusicLabel,
					Tracks = album.Tracks
					.Select(musicTracks => new TrackDto
					{
						TrackName = musicTracks.TrackName,
						Duration = musicTracks.Duration
					})
					.OrderBy(track => track.Duration)
					.ToList()
				})
				.FirstOrDefaultAsync();
			}
		}

		public async Task DeleteMusicianAsync(int idMusician)
		{
			using (var transaction = await _databaseContext.Database.BeginTransactionAsync())
			{
				try
				{
					var found = await _databaseContext.Musicians
						.Where(musician => musician.IdMusician.Equals(idMusician))
						.AnyAsync(musician => musician.MusicTracks
							.Select(musicTrack => musicTrack.Track)
							.Any(track => track.IdMusicAlbum == null)
						);

					if (found)
					{
						var musician = new Musician { IdMusician = idMusician };

						_databaseContext.Musicians.Attach(musician);
						_databaseContext.Musicians.Remove(musician);

						await _databaseContext.SaveChangesAsync();
						await transaction.CommitAsync();
					}
				}
				catch (Exception)
				{
					await transaction.RollbackAsync();
				}
			}
		}
	}
}
