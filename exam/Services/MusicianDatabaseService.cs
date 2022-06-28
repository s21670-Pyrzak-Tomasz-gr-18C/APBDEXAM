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


		public async Task<TeamDto> GetTeamAsync(int idTeam)
		{
			using (var Transaction = await _databaseContext.Database.BeginTransactionAsync())
			{
				return await _databaseContext.Teams
				.Where(team => team.TeamID == idTeam)
				.Select(team => new TeamDto
				{
					TeamName = team.TeamName,
					OrganizationID = team.OrganizationID,
					TeamDescription = team.TeamDescription,
					Organization = team.Organization,
					Memberships = team.Memberships
					.Select(membership => new MembershipDTO
					{
						Member = membership.Member,
					})
					.OrderBy(membership => membership.MembershipDate)
					.ToList()
				})
				.FirstOrDefaultAsync();
			}
		}

	
}
