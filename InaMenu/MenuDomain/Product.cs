using System;

namespace InaMenu.MenuDomain
{
    public enum Currency
    {
        USD,
        EUR,
        TWD,
    }
    public struct Price
    {
        public Currency Currency { get; private set; }
        public Double Quantity { get; private set; }

        public Price(Currency currency, Double quantity)
        {
            Currency = currency;
            Quantity = quantity;
        }
    }

    

    public class Product
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public Price Price { get; private set; }

        public Product(
            string id,
            string name,
            Price price
            )
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public void ChangeName(string name)
        {
            Name = name;
        }
        public void ChangePrice(Price newPrice)
        {
            Price = newPrice;
        }

    }
}
