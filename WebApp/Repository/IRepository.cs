namespace WebApp.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);//Add Save Change
        void Update(T entity);
        void Delete(int id);
        void Save();//Save Change
    }
}
