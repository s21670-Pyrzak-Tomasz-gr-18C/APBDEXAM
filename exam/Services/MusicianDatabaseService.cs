using exam.Models;

namespace exam.Services
{
	public class MusicianDatabaseService : IMusicianDatabaseService
	{
		private readonly DatabaseContext _databaseContext;

		public MusicianDatabaseService(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}
	}
}
