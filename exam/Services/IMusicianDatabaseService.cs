using System.Threading.Tasks;

using exam.Models.DTO;

namespace exam.Services
{
	public interface IMusicianDatabaseService
	{
		Task<MusicianDto> GetMusicianAsync(int idMusician);
	}
}
