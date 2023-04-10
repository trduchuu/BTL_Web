using CoffeeShopManagement.Models;

namespace CoffeeShopManagement.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly CoffeeShopManagementContext _context;
        public MenuRepository(CoffeeShopManagementContext context)
        {
            _context = context;
        }

        public Menu Add(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
            return menu;
        }

        public Menu Delete(Menu menu)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetAllMenu()
        {
            return _context.Menus;
        }

        public Menu getMenu(Menu menu)
        {
            return _context.Menus.Find(menu);
        }

        public Menu Update(Menu menu)
        {
            _context.Update(menu);
            _context.SaveChanges();
            return menu;
        }
    }
}
