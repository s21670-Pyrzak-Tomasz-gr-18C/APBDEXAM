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

		public async Task<MusicianDto> GetMusicianAsync(int idMusician)
		{
			using (var Transaction = await _databaseContext.Database.BeginTransactionAsync())
			{
				return await _databaseContext.Musicians
				.Where(musician => musician.IdMusician == idMusician)
				.Select(musician => new MusicianDto
				{
					FirstName = musician.FirstName,
					LastName = musician.LastName,
					Nickname = musician.Nickname,
					Tracks = musician.MusicTracks
					.Select(musicTracks => new TrackDto
					{
						TrackName = musicTracks.Track.TrackName,
						Duration = musicTracks.Track.Duration
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
