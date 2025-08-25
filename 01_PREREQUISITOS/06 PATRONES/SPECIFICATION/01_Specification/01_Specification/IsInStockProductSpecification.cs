namespace _01_Specification
{
    public class IsInStockProductSpecification : CompositeSpecification<Product> 
    {
        public override bool IsSatisfiedBy(Product product)
        {
            return product.Stock > 0;
        }
    }
}
