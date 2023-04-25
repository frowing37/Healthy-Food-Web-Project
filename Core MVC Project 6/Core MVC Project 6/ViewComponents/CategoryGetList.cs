using Core_MVC_Project_6.Repositeries;
using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_Project_6.ViewComponents
{
	public class CategoryGetList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CategoryRepositeries cRepo = new CategoryRepositeries();

			var categoryList = cRepo.TList();

			return View(categoryList);
		}
	}
}
