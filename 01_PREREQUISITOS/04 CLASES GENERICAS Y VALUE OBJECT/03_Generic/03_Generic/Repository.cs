namespace _03_Generic
{
    public class Repository<T>
    {
        private List<T> _list = new List<T>();

        public void Add(T item)
        {
            _list.Add(item);
        }

        public List<T> GetList() 
        { 
            return _list;
        }
    }
}
