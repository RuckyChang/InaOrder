using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InaMenu.MenuDomain
{
    public interface MenuRepository: IHostedService
    {
        public Task<List<Menu>> All();
        public Task<Menu> OfId(string id);
        public Task<string> Save(Menu menu);
    }
}
