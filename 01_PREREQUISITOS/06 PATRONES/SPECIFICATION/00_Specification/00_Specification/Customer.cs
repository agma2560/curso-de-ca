namespace _00_Specification
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsPremium { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
