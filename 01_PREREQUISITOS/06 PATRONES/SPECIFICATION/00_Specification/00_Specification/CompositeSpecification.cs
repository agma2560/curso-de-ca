namespace _00_Specification
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T candidate);

        void ISpecification<T>.IsSatisfiedBy(T candidate)
        {
            throw new NotImplementedException();
        }
    }
}
