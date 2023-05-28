namespace feedApi.Users
{
    public interface IGenericService<T> where T : class
    {
        public T Create(T entity);

        public bool Delete(int id);

        public IEnumerable<T> Find();

        public T? FindOne(int id);

        public T? FindBy(Func<T, bool> filter);

        public T? Update(int id, T entity);
    }
}