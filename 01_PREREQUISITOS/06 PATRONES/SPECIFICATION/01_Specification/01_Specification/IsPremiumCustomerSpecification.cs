namespace _01_Specification
{
    public class IsPremiumCustomerSpecification : CompositeSpecification<Customer> // ¡Debe heredar de CompositeSpecification<Customer>!
    {
        public override bool IsSatisfiedBy(Customer customer)
        {
            return customer.IsPremium;
        }
    }
}

