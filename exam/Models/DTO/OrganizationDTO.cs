namespace exam.Models.DTO
{
	public class OrganizationDTO
	{
		public string OrganizationName { get; set; }
		public string OrganizationDomain { get; set; }

		public virtual ICollection<Member> Members { get; set; }

		public virtual ICollection<Team> Teamss { get; set; }
	}
}
