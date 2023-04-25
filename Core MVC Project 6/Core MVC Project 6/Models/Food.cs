using System.ComponentModel.DataAnnotations;

namespace Core_MVC_Project_6.Models
{
	public class Food
	{
		[Key]
        public int FoodID { get; set; }

        [Required(ErrorMessage = "This area should not empty")]
        public string FoodName { get; set; }

        [Required(ErrorMessage = "This area should not empty")]
        public string FoodDescription { get; set;}

        [Required(ErrorMessage = "This area should not empty")]
        public int FoodPrice { get; set; }

        [Required(ErrorMessage = "This area should not empty")]
        public string FoodImageURL { get; set; }

        [Required(ErrorMessage = "This area should not empty")]
        public int FoodStock { get; set; }
        public int CategoryID { get; set; }
        public bool Status { get; set; }
        public virtual Category Category { get; set; }
    }
}
