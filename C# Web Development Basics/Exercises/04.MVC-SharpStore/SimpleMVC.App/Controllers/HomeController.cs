namespace SimpleMVC.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    using ViewModels;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<ProductViewModel>> Products()
        {
            var products = this.GetProducts();

            return View(products);
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }
        private IEnumerable<ProductViewModel> GetProducts()
        {
            var knives = DataSingleton.Context.Knives;
            var viewModels = new List<ProductViewModel>();
            foreach (var knife in knives)
            {
                viewModels.Add(new ProductViewModel()
                {
                    Id = knife.Id,
                    Price = knife.Price,
                    Name = knife.Name,
                    ImageUrl = knife.ImageUrl
                });
            }

            return viewModels;
        }
    }
}
