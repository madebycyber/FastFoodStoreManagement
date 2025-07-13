using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FastFoodWebApp.Models;  // Namespace của Product Model

namespace FastFoodWebApp.Controllers
{
    public class ProductController : Controller
    {
        // Danh sách sản phẩm tạm thời (thay thế bằng database trong thực tế)
        private static List<Product> _products = new List<Product>
        {
            new Product { ProductId = "PRD001", ProductName = "Burger", CategoryId = "CAT01", Description = "Delicious beef burger", Price = 5.99m },
            new Product { ProductId = "PRD002", ProductName = "Coke", CategoryId = "CAT02", Description = "Refreshing cola drink", Price = 1.99m }
        };

        // GET: Product/Index
        public IActionResult Index(string keyword, string categoryId)
        {
            var products = _products.AsQueryable();

            // Lọc theo từ khóa (tìm trong tên và mô tả)
            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(p => p.ProductName.Contains(keyword) || (p.Description != null && p.Description.Contains(keyword)));
            }

            // Lọc theo CategoryId
            if (!string.IsNullOrEmpty(categoryId))
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

            return View(products.ToList());
        }

        // GET: Product/Details/PRD001
        public IActionResult Details(string id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = GenerateProductId();
                _products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/PRD001
        public IActionResult Edit(string id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/PRD001
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            var existingProduct = _products.FirstOrDefault(p => p.ProductId == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/PRD001
        public IActionResult Delete(string id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/PRD001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }

        // Phương thức sinh mã ProductId mới tự động
        private string GenerateProductId()
        {
            int nextId = _products.Count + 1;
            return $"PRD{nextId:D3}";  // Ví dụ: PRD001, PRD002, PRD003...
        }
    }
}
