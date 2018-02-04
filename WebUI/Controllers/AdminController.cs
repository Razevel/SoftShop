using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class Config
    {
        public string GoogleLink { get; }= "#";
        public string VkLink { get; }= "#";
        public string OkLink { get; } = "#"; 

        public enum AdminCategories
        {
            Catalog = 0,
            Orders = 1,
        }

        public static Dictionary<AdminCategories, string> AdminCategoriesPaths { get; } = new Dictionary<AdminCategories, string>()
        {
            {AdminCategories.Catalog, "Каталог"},
            {AdminCategories.Orders, "Заказы"}
        };
    }

    public class AdminIndexViewModel
    {
        public Dictionary<Config.AdminCategories, string>
            Categories = Config.AdminCategoriesPaths; 

        public int CurrentCategory { get; set; } = 0;
    }

    public class AdminController : Controller
    {
        private readonly IRepository<Product> _products;
        private readonly IRepository<Order> _orders;

        public AdminController(IRepository<Product> products, IRepository<Order> orders)
        {
            _products = products;
            _orders = orders;
        }

        public ActionResult Index()
        {
            return View((new AdminIndexViewModel()));
        }

        public PartialViewResult Category(int categoryID)
        {

            if (categoryID == (int)Config.AdminCategories.Catalog)
                return PartialView("_AdminCatalogPartial", _products.All.ToArray());
            if (categoryID == (int)Config.AdminCategories.Orders)
                return PartialView("_AdminOrdersPartial", _orders.All.ToArray());

            return PartialView("Error");
        }

        public ActionResult ProductEdit(int id)
        {
            var p = _products.All.FirstOrDefault(x => x.ID == id);
            if (p != null)
                return View(p);
            else
                return View("Error");
        }

    }
}