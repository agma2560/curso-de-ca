namespace _00_Specification
{
    public class RegisteredBeforeDateSpecification : CompositeSpecification<Customer>
    {
        DateTime _date;

        public RegisteredBeforeDateSpecification(DateTime date) 
        { 
            _date = date;
        }

        public override bool IsSatisfiedBy(Customer customer)
        {
            return customer.RegistrationDate < _date;
        }
    }
}
