namespace _00_Specification
{
    public interface ISpecification<T>
    {
        void IsSatisfiedBy(T candidate);
    }
}
