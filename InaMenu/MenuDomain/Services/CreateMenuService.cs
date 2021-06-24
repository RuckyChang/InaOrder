using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace InaMenu.MenuDomain.Services
{
    public class CreateMenuService
    {
        private MenuRepository _repository;

        public CreateMenuService(MenuRepository repository){
            _repository = repository;
        }

        public Task<string> Execute(
            string name,
            Dictionary<string, Product> products,
            Status status
            )
        {
            Menu menu = new Menu(
                GenerateUUID(),
                name,
                products,
                status
                );

            return _repository.Save(menu);
        }

        private string GenerateUUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
