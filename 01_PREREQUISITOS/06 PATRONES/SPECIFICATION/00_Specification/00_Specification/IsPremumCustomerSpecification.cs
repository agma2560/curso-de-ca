namespace _00_Specification
{
    public class IsPremumCustomerSpecification : CompositeSpecification<Customer>
    {
        public override bool IsSatisfiedBy(Customer customer)
        {
            return customer.IsPremium;
        }
    }
}
