using eCommerce.Contracts.Repositories;
using eCommerce.DAL.Data;
using eCommerce.DAL.Repositories;
using eCommerce.Model;
using eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Basket> baskets;
        BasketService basketService;

        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Basket> baskets)
        {
            this.customers = customers;
            this.products = products;
            this.baskets = baskets;
            basketService = new BasketService(this.baskets);
        }
        public ActionResult BasketSummary() {
            var model = basketService.GetBasket(this.HttpContext);
            
            return View(model.BasketItems);
        }
       
        public ActionResult AddToBasket(int id) {
            basketService.AddToBasket(this.HttpContext, id, 1);//always add one to the basket

            return RedirectToAction("BasketSummary");
        }

        public ActionResult Index()
        {
            var productList = products.GetAll();
         
            return View(productList);
        }

        public ActionResult Details(int id) {
            var product = products.GetById(id);

            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}