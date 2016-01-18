namespace CashRegister
{
    public class Product
    {
        public Product(string id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
    }
}