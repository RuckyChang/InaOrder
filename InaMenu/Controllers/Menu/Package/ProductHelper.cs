using System.Collections.Generic;

namespace InaMenu.Controllers.Menu.Package
{
    public class ProductHelper
    {
        public static Dictionary<string, Product> ConvertToHttpPackageProduct(Dictionary<string, MenuDomain.Product> products)
        {
            Dictionary<string, Product> result = new Dictionary<string, Product>();
            foreach (var kvp in products)
            {
                result.Add(kvp.Key, ConvertToHttpPackageProduct(kvp.Value));
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
