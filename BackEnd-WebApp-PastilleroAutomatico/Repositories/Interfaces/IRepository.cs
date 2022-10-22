namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        T findId(object Id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
