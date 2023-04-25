using System.ComponentModel.DataAnnotations;

namespace Core_MVC_Project_6.Models
{
	public class Category
	{
		[Key]
        public int CategoryID { get; set; }

		[Required(ErrorMessage = "This area should not empty")]
		public string CategoryName { get; set; }

        [Required(ErrorMessage = "This area should not empty")]
        public string CategoryDescription { get; set; }

        public bool Status { get; set; }
        public List<Food> FoodList { get; set; }
    }
}
