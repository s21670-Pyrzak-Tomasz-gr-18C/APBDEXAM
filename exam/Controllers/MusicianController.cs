using exam.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exam.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MusicianController : ControllerBase
	{
		private readonly IMusicianDatabaseService _databaseService;

		public MusicianController(IMusicianDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}
	}
}
