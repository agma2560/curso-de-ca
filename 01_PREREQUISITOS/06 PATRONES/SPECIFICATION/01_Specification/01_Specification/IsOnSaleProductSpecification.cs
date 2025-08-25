namespace _01_Specification
{
    public class IsOnSaleProductSpecification : CompositeSpecification<Product> // ¡Debe heredar de CompositeSpecification<Product>!
    {
        public override bool IsSatisfiedBy(Product product)
        {
            return product.DiscountPercentage > 0;
        }
    }
}
