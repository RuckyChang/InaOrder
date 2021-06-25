using System.Collections.Generic;

namespace InaMenu.MenuDomain
{
    public enum MenuStatus {
        Diabled = 0,
        Enabled = 1
    }

    public class Menu
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, Product> Products { get; set; }
        public MenuStatus Status { get; set; }

        public Menu(
           string id,
           string name,
           Dictionary<string, Product> products,
           MenuStatus status
           )
        {
            Name = name;
            Products = products;
            Status = status;
            Id = id;
        }

        public void ChangeName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
        }

        public void ChangeStatus(MenuStatus status)
        {
            Status = status;
        }

        public void AppendProduct(Product product)
        {
            if (Products.ContainsKey(product.Id))
            {
                Products[product.Id] = product;
                return;
            }

            Products.Add(product.Id, product);
        }

        public void RemoveProduct(Product product)
        {
            if (Products.ContainsKey(product.Id))
            {
                Products.Remove(product.Id);
                return;
            }
        }

        public void Enable()
        {
            Status = MenuStatus.Enabled;
        }

        public void Disable()
        {
            Status = MenuStatus.Diabled;
        }
    }
}
