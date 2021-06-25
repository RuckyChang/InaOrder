using InaMenu.MenuDomain;
using System.Collections.Generic;

namespace InaMenu.Controllers.Menu.Package
{
    public class ProductHelper
    {
        public static Dictionary<string, MenuDomain.Product> ConvertToDomainProduct(List<Product> products)
        {
            Dictionary<string, MenuDomain.Product> result = new Dictionary<string, MenuDomain.Product>();

            foreach (var product in products)
            {
                var Price = product.Price;

                result.Add(product.Id, new MenuDomain.Product(
                    id: product.Id,
                    name: product.Name,
                    price: new MenuDomain.Price(
                        currency: (Currency)Price.Currency,
                        quantity: Price.Quantity
                        )
                ));
            }

            return result;
        }

        public static List<Product> ConvertToHttpPackageProduct(Dictionary<string, MenuDomain.Product> products)
        {
            List<Product> result = new List<Product>();
            foreach (var kvp in products)
            {
                result.Add(ConvertToHttpPackageProduct(kvp.Value));
            }

            return result;
        }

        public static Product ConvertToHttpPackageProduct(MenuDomain.Product product)
        {

            Price price = ConvertToHttpPackagePrice(product.Price);

            return new Product(
                product.Id,
                product.Name,
                price
                );
        }

        public static Price ConvertToHttpPackagePrice(MenuDomain.Price price)
        {
            return new Price(
                (int)price.Currency,
                price.Quantity
                );
        }
    }
}
