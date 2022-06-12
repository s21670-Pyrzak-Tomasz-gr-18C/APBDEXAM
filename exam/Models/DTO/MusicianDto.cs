using System.Collections.Generic;

namespace exam.Models.DTO
{
	public class MusicianDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? Nickname { get; set; }

		public IEnumerable<TrackDto> Tracks { get; set; }
	}
}
