using CoffeeShopManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopManagement.ViewComponents
{
    public class ThucDonMenuViewComponent : ViewComponent
    {
        private readonly IMenuRepository _menuRepository;
        public ThucDonMenuViewComponent(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public IViewComponentResult Invoke()
        {
            var menu = _menuRepository.GetAllMenu().OrderBy(x => x.TenMenu);
            return View(menu);
        }
    }
}
