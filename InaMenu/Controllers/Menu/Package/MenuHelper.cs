using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaMenu.Controllers.Menu.Package
{
    public class MenuHelper
    {
        public static List<Menu> ConvertToHttpPackageMenu(List<MenuDomain.Menu> menus)
        {
            List<Menu> list = new List<Menu>();
            foreach(var data in menus)
            {
                list.Add(ConvertToHttpPackageMenu(data));
            }

            return list;
        }

        public static Menu ConvertToHttpPackageMenu(MenuDomain.Menu menu)
        {
            return new Menu()
            {
                Id = menu.Id,
                Name = menu.Name,
                Products = ProductHelper.ConvertToHttpPackageProduct(menu.Products),
                Status = (int)menu.Status
            };
        }
    }
}
