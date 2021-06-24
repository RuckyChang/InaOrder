using System.Collections.Generic;

namespace InaMenu.MenuDomain
{
    public enum Status {
        Diabled = 0,
        Enabled = 1
    }

    public class Menu
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, Product> Products { get; set; }
        public Status Status { get; set; }

        public Menu(
           string id,
           string name,
           Dictionary<string, Product> products,
           Status status
           )
        {
            Name = name;
            Products = products;
            Status = status;
            Id = id;
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
            Status = Status.Enabled;
        }

        public void Disable()
        {
            Status = Status.Diabled;
        }
    }
}
