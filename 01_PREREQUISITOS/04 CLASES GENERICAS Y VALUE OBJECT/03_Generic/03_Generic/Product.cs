namespace _03_Generic
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public Product(int id, string productName, int quantity)
        {
            Id = id;
            ProductName = productName;
            Quantity = quantity;
        }
    }
}
