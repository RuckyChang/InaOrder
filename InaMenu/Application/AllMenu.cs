using InaMenu.MenuDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InaMenu.Application
{
    public class AllMenu
    {
        private MenuRepository _repo;
        public AllMenu(MenuRepository repo) {
            _repo = repo;
        }

        public Task<List<Menu>> Execute()
        {
            return _repo.All();
        }
    }
}
