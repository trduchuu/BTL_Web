using CoffeeShopManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CoffeeShopManagement.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/home")]
    public class HomeController : Controller
    {
        CoffeeShopManagementContext db = new CoffeeShopManagementContext();
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("sanpham")]
        public ActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.SanPhams.AsNoTracking().OrderBy(x => x.TenSanPham);
            PagedList<SanPham> lst = new PagedList<SanPham>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }

        [Route("create")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdMenu = new SelectList(db.Menus.ToList(), "IdMenu", "TenMenu");
            ViewBag.IdTopping = new SelectList(db.Toppings.ToList(), "IdTopping", "TenTopping");
            ViewBag.IdSize = new SelectList(db.Sizes.ToList(), "IdSize", "TenSize");
            return View();
        }
        [Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            ViewBag.IdMenu = new SelectList(db.Menus.ToList(), "IdMenu", "TenMenu", sanPham.IdMenu);
            ViewBag.IdTopping = new SelectList(db.Toppings.ToList(), "IdTopping", "TenTopping", sanPham.IdTopping);
            ViewBag.IdSize = new SelectList(db.Sizes.ToList(), "IdSize", "TenSize", sanPham.IdSize);
            return View(sanPham);
            
        }

        [Route("edit")]
        [HttpGet]
        public ActionResult Edit(string idSanPham)
        {
            ViewBag.IdMenu = new SelectList(db.Menus.ToList(), "IdMenu", "TenMenu");
            ViewBag.IdTopping = new SelectList(db.Toppings.ToList(), "IdTopping", "TenTopping");
            ViewBag.IdSize = new SelectList(db.Sizes.ToList(), "IdSize", "TenSize");
            var sanPham = db.SanPhams.Find(idSanPham);
            return View(sanPham);
        }
        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            ViewBag.IdMenu = new SelectList(db.Menus.ToList(), "IdMenu", "TenMenu", sanPham.IdMenu);
            ViewBag.IdTopping = new SelectList(db.Toppings.ToList(), "IdTopping", "TenTopping", sanPham.IdTopping);
            ViewBag.IdSize = new SelectList(db.Sizes.ToList(), "IdSize", "TenSize", sanPham.IdSize);
            return View(sanPham);

        }

        



    }
}
