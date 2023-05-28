namespace feedApi.Users
{
    public abstract class GenericService<T> : IGenericService<T> where T : class
    {
        public IGenericRepository<T> repository;

        public GenericService(AppDbContext learnDb)
        {
            this.repository = new GenericRepository<T>(learnDb);
        }

        public virtual T Create(T entity)
        {
            return this.repository.Add(entity);
        }

        public bool Delete(int id)
        {
            return this.repository.Remove(id);
        }

        public IEnumerable<T> Find()
        {
            return this.repository.List();
        }

        public T? FindOne(int id)
        {
            return this.repository.FindOne(id);
        }

        public T? FindBy(Func<T, bool> filter)
        {
            return this.repository.Single(filter);
        }

        public T? Update(int id, T payload)
        {
            var entity = this.repository.FindOne(id);

            if (entity is null)
            {
                return null;
            }

            this.repository.Update(entity);
            return entity;
        }
    }
}