using FastFoodWebApp.Data;
using FastFoodWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodWebApp.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly FastFoodStoreContext fastFoodStoreContext;

        public ProductController1 (FastFoodStoreContext context)
        {
            fastFoodStoreContext = context;
        }

        private static List<Product> listproducts = new List<Product>
        {
            new Product { ProductId = "PRD001", ProductName = "Pizza", CategoryId = "CAT03", Description = "Delicious Seafood Pizza", Price = 20000 },
            new Product { ProductId = "PRD002", ProductName = "Spagheti", CategoryId = "CAT04", Description = "Spagheti for every ages", Price = 30000 }
        };
        // GET: ProductController1
        public IActionResult Index()
        {
            var _products = fastFoodStoreContext.Products.ToList();
            return View(_products);
        }

        // GET: ProductController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController1/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: ProductController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
