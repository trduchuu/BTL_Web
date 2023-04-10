using CoffeeShopManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeeShopManagement.Controllers
{
    public class HomeController : Controller
    {
        CoffeeShopManagementContext db = new CoffeeShopManagementContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lstSanPham = db.SanPhams.Take(6).ToList();
            return View(lstSanPham);
        }

        public IActionResult ChiTietSanPham(String maSp)
        {
            var SanPham = db.SanPhams.SingleOrDefault(x => x.IdSanPham == maSp);
            return View(SanPham);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}