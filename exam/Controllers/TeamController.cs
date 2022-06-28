using System.Threading.Tasks;
using System;

using exam.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exam.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeamController : ControllerBase
	{
		private readonly IMusicianDatabaseService _databaseService;

		public TeamController(IMusicianDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		[HttpGet]
		public async Task<IActionResult> GetTeamAsync([FromQuery] string idTeam)
		{
			if (idTeam == null)
				return BadRequest("No ID provided");

			return Ok(await _databaseService.GetTeamAsync(Convert.ToInt32(idTeam)));
		}

	
	}
}
