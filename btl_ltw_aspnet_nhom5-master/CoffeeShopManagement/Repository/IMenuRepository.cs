using CoffeeShopManagement.Models;
namespace CoffeeShopManagement.Repository
{
    public interface IMenuRepository
    {
        Menu Add(Menu menu);
        Menu Update(Menu menu);
        Menu Delete(Menu menu);
        Menu getMenu(Menu menu);
        IEnumerable<Menu> GetAllMenu();
    }
}
