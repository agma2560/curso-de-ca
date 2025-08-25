
namespace _02_Interfaces02
{
    public class DBRepository<T> : IRepository<T>
    {
        private List<T> _list = new List<T>();

        public void Add(T entity)
        {
            _list.Add(entity);
            Console.WriteLine("Elemento agregado");
        }

        public IEnumerable<T> GetAll()
        {
            return _list;
        }

        public void Remove(T entity)
        {
            _list.Remove(entity);
            Console.WriteLine("Elemento removido");
        }
    }
}
