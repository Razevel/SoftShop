using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRepository<Product> _products;
        public CatalogController(IRepository<Product> products)
        {
           _products = products;
        }
        
        public ActionResult Index(string search = "")
        {
            //todo: Если название полностью соответствует категории, то перекинуть на категорию
            
            ViewBag.Message = "Все товары";

            var result = _products.All.ToArray();
            if (search == "") return View(result);

            
            ViewBag.Message = $"Все товары по запросу \"{search}\"";
            //По имени, описанию и категории

            search = search.ToLowerInvariant();
            result = result
                .Where(p => p.Name.ToLowerInvariant().Contains(search) 
                            || p.About.ToLowerInvariant().Contains(search)
                            || p.Category.Name.ToLowerInvariant().Contains(search)
                            ).ToArray();
            return View(result);
        }
        
    }
}