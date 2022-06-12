using System.Threading.Tasks;
using System;

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

		[HttpGet]
		public async Task<IActionResult> GetMusicianAsync([FromQuery] string idMusician)
		{
			if (idMusician == null)
				return BadRequest("No ID provided");

			return Ok(await _databaseService.GetMusicianAsync(Convert.ToInt32(idMusician)));
		}
	}
}
