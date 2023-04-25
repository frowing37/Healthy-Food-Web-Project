using Microsoft.AspNetCore.Mvc;
using Core_MVC_Project_6.Data;
using Core_MVC_Project_6.Models;

namespace Core_MVC_Project_6.Controllers
{
    public class GraphController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProductList());
        }

        public List<Product> ProductList()
        {
            List<Product> products = new List<Product>();

            using (var pros = new Context())
            {
                products = pros.Foods.Select(x => new Product
                {
                    foodname = x.FoodName,
                    foodstock = x.FoodStock
                }).ToList();
            }

            return products;
        }

    }
}
