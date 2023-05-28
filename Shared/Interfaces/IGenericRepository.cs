namespace feedApi.Shared
{
    public interface IGenericRepository<T> where T : class
    {
        public T Add(T entity);

        public bool Remove(int id);

        public IEnumerable<T> List();

        public T FindOne(int id);

        public T Single(Func<T, bool> filter);

        public T Update(T entity);
    }
}