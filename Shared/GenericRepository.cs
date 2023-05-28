using System;
using Microsoft.EntityFrameworkCore;

namespace feedApi.Users
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
            return entity;
        }

        public bool Remove(int id)
        {
            var entity = this.DbSet.Find(id);

			if (entity is null) {
				return false;
			}

			this.DbSet.Remove(entity);
			return true;
        }

        public IEnumerable<T> List()
        {
            return this.DbSet.ToList();
        }

        public T? FindOne(int id)
        {
            return this.DbSet.Find(id);
        }

        public T? Single(Func<T, bool> filter)
        {
            return this.DbSet.SingleOrDefault(filter);
        }

        public T Update(T entity)
        {
			this.DbSet.Update(entity);
			return entity;
        }
    }
}
