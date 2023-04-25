using System.ComponentModel.DataAnnotations;

namespace Core_MVC_Project_6.Models
{
	public class Admin
	{
		[Key]
		public int AdminID { get; set; }

		[StringLength(20)]
		public string AdminName { get; set; }

		[StringLength(20)]
		public string Password { get; set; }

		[StringLength(1)]
		public string AdminRole { get; set; }

		public bool KeepLoggedIn { get; set; }
	}
}
