namespace _01_Specification
{
    public class RegisteredBeforeDateSpecification : CompositeSpecification<Customer> // ¡Debe heredar de CompositeSpecification<Customer>!
    {
        private readonly DateTime _date;

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
