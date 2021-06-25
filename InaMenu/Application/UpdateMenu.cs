using InaMenu.MenuDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InaMenu.Application
{
    public class UpdateMenu
    {
        private MenuRepository _repo;

        public string Name { get; set; }
        public Dictionary<string, Product> Products { get; set; }
        public MenuStatus Status { get; set; }

        public UpdateMenu(MenuRepository repo)
        {
            _repo = repo;
        }

        public async Task Execute(string id)
        {
            var menu = await _repo.OfId(id);

            menu.ChangeName(Name);
            menu.ChangeStatus(Status);

            List<Product> productsToAdd = GetProductsToAdd(menu, Products);
            foreach(var product in productsToAdd)
            {
                menu.AppendProduct(product);
            }

            List<Product> productsToRemove = GetProductsToRemove(menu, Products);
            foreach (var product in productsToRemove)
            {
                menu.RemoveProduct(product);
            }

            await _repo.Save(menu);
        }

        private List<Product> GetProductsToAdd(Menu menu, Dictionary<string, Product> products)
        {
            List<Product> productsToAdd = new List<Product>();

            foreach(var data in products)
            {
                if (!menu.Products.ContainsKey(data.Key)){
                    productsToAdd.Add(data.Value);
                }
            }

            return productsToAdd;
        }

        private List<Product> GetProductsToRemove(Menu menu, Dictionary<string, Product> products)
        {
            List<Product> productToRemove = new List<Product>();

            foreach (var data in menu.Products)
            {
                if (!products.ContainsKey(data.Key))
                {
                    productToRemove.Add(data.Value);
                }
            }

            return productToRemove;
        }
    }
}
