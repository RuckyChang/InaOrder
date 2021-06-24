using InaMenu.MenuDomain;
using System.Threading.Tasks;

namespace InaMenu.Application
{
    public class MenuOfId
    {
        private MenuRepository _repo;

        public MenuOfId(MenuRepository repo) {
            _repo = repo;
        }

        public Task<Menu> Execute(string id)
        {
            return _repo.OfId(id);
        }
    }
}
