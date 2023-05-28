using ErrorManagement.Exceptions;
using feedApi.AppDbContextNS;
using Microsoft.EntityFrameworkCore;

namespace feedApi.Shared
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _dbContext;
        internal DbSet<T> DbSet { get; set; }

        public GenericRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.DbSet=this._dbContext.Set<T>();
        }

        public T Add(T entity)
        {
			this.DbSet.Add(entity);
            this._dbContext.SaveChanges();
            return entity;
        }

        public bool Remove(int id)
        {
            var entity = this.DbSet.Find(id);

			if (entity is null) {
				throw new NotFoundException("Entity not found!");
			}

			this.DbSet.Remove(entity);
            this._dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<T> List()
        {
            return this.DbSet.ToList();
        }

        public T FindOne(int id)
        {
            var entity = this.DbSet.Find(id);

            if (entity is null)
            {
                throw new NotFoundException("Entity not found!");
            }

            return entity;
        }

        public T? Single(Func<T, bool> filter)
        {
            var entity = this.DbSet.SingleOrDefault(filter);

            if (entity is null)
            {
                throw new NotFoundException("Entity not found!");
            }

            return entity;
        }

        public T Update(T entity)
        {
			this.DbSet.Update(entity);
            this._dbContext.SaveChanges();
            return entity;
        }
    }
}
