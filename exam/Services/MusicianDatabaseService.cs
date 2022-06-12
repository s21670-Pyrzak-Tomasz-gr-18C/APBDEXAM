using System.Linq;
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
	}
}
