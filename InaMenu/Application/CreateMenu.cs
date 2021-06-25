using InaMenu.MenuDomain;
using InaMenu.MenuDomain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InaMenu.Application
{
    public class CreateMenu
    {
        private MenuRepository _repo;

        public CreateMenu(MenuRepository repo){
            _repo = repo;
        }

        public Task<string> Execute(
            string name,
            Dictionary<string, Product> products,
            MenuStatus status
            )
        {
            CreateMenuService service = new CreateMenuService(_repo);

            return service.Execute(
                name,
                products,
                status
            );
        }
    }
}
