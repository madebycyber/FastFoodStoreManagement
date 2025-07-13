using Microsoft.AspNetCore.Mvc;
using FastFoodWebApp.Models;  // Namespace của model Product
using System.Collections.Generic;
using System.Linq;

namespace FastFoodWebApp.Controllers
{
    public class CartController : Controller
    {
        // Giỏ hàng lưu tạm
        private static List<Product> Cart = new List<Product>();

        // Hiển thị giỏ hàng
        public IActionResult Index()
        {
            return View(Cart);
        }

        // Thêm sản phẩm vào giỏ
        [HttpPost]
        public IActionResult AddToCart(Product product)
        {
            if (product != null)
            {
                // Kiểm tra nếu sản phẩm đã tồn tại trong giỏ hàng
                var existingProduct = Cart.FirstOrDefault(p => p.ProductId == product.ProductId);
                if (existingProduct != null)
                {
                    // Nếu đã tồn tại, tăng số lượng (giả sử cần thêm thuộc tính Quantity)
                    existingProduct.Price += product.Price;  // Giá tăng khi thêm số lượng
                }
                else
                {
                    Cart.Add(product); // Thêm sản phẩm mới vào giỏ hàng
                }
            }
            return RedirectToAction("Index", "Cart"); // Chuyển hướng đến giỏ hàng
        }

        // Xóa sản phẩm khỏi giỏ
        [HttpPost]
        public IActionResult RemoveFromCart(string productId)
        {
            var item = Cart.FirstOrDefault(p => p.ProductId == productId);
            if (item != null)
            {
                Cart.Remove(item);
            }
            return RedirectToAction("Index");
        }

        // Hiển thị trang Checkout
        public IActionResult Checkout()
        {
            return View(Cart); // Truyền danh sách sản phẩm trong giỏ hàng vào View Checkout
        }

        // Xử lý sau khi khách hàng xác nhận đơn hàng
        public IActionResult ConfirmOrder()
        {
            Cart.Clear(); // Xóa giỏ hàng sau khi xác nhận đơn hàng
            TempData["Message"] = "Order confirmed! Thank you for your purchase.";
            return RedirectToAction("Index"); // Chuyển về giỏ hàng với thông báo
        }
    }
}
