using Jwt.Models;

namespace Jwt.Constants
{
    public class ListProduct
    {
        public static readonly List<Product> listProduct = new List<Product>()
        {
            new Product {Name = "Sardina", Quantity = 10},
            new Product {Name = "Salmon", Quantity = 4},
            new Product {Name = "Zanahoria", Quantity = 7}
        };
    }
}
