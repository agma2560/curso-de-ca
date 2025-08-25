namespace _01_Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}
