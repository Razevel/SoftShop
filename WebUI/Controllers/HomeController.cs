using Domain.Abstract;
using Domain.Entities;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Product> _products;

        public HomeController(IRepository<Product> products)
        {
            _products = products;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}