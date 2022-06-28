using System.Collections.Generic;

namespace exam.Models.DTO
{
	public class MemberDto
	{
		public int OrganizationID { get; set; }
		public string MemberName { get; set; }
		public string MemberSurname { get; set; }
		public string MemberNickName { get; set; }

		public virtual ICollection<Membership> Memberships { get; set; }

		public virtual Models.Organization Organization { get; set; }
	}
}
