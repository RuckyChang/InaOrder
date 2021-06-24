namespace InaMenu.Controllers.Menu.Package
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }

        public Product(string id, string name, Price price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
