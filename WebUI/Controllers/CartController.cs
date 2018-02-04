using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository<Product> _products;

        public CartController(IRepository<Product> products)
        {
            _products = products;
        }

        public ActionResult Index()
        {
            return View(GetCart());
        }

        public PartialViewResult Viget()
        {
            return PartialView(GetCart());
        }

        public PartialViewResult CartTable()
        {
            return PartialView("_IndexOrdersPartial", GetCart());
        }

        public Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];
            if (cart != null) return cart;
            cart = new Cart {SessionID = Session.SessionID};
            Session["Cart"] = cart;
            return cart;
        }

        public PartialViewResult Add(int id, int q = 1)
        {
            var p = _products.All.FirstOrDefault(x => x.ID == id);
            if (p != null)
                GetCart().Add(p, q);
            return PartialView("Viget", GetCart());
        }

        public PartialViewResult Remove(int id, int q = 0, string pageType = "")
        {
            var p = _products.All.FirstOrDefault(x => x.ID == id);
            if (p != null)
                GetCart().Remove(p, q);
            if (pageType == "cartIndex")
                return PartialView("_IndexOrdersPartial", GetCart());
            return PartialView("Viget", GetCart());
        }

        public PartialViewResult Clear()
        {
            GetCart().Clear();
            return PartialView("Viget", GetCart());
        }

        
    }
}