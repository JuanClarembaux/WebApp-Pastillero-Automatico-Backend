using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        internal DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll() => dbSet.ToList();
        public virtual T findId(object Id)
        {
            return dbSet.Find(Id);
        }
        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            context.Set<T>().Update(entity);
            /*
            dbSet.Attach(entity);//traigo los nuevos valores 
            context.Entry(entity).State = EntityState.Modified;
            */
        }

        public virtual void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
    }
}
