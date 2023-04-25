using Microsoft.EntityFrameworkCore;

namespace Core_MVC_Project_6.Models
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=DESKTOP-N9TUFUP; Database=Db_MVC6; Integrated Security = true; TrustServerCertificate=true;");
		}

		public DbSet<Food> Foods { get; set; }
		public DbSet<Category> Categories { get; set; }

		public DbSet<Admin> Admins { get; set; }
	}
}
