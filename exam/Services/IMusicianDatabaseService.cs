using System.Threading.Tasks;

using exam.Models.DTO;

namespace exam.Services
{
	public interface IMusicianDatabaseService
	{
		Task<AlbumDto> GetMusicianAsync(int idMusician);
	}
}
