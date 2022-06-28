using System;
using System.Collections.Generic;

namespace exam.Models.DTO
{
    public class TeamDto
    {
		public int OrganizationID { get; set; }
		public string TeamName { get; set; }
		public string TeamDescription { get; set; }

		public virtual ICollection<Membership> Memberships { get; set; }

		public virtual Models.Organization Organization { get; set; }
	}
}
