using InaMenu.MenuDomain;
using System.Threading.Tasks;

namespace InaMenu.Application
{
    public class DeleteMenu
    {
        private MenuRepository _repo;
  
        public DeleteMenu(MenuRepository repo)
        {
            _repo = repo;
        }

        public async Task Execute(string id)
        {
            await _repo.Remove(id);
        }
    }
}
