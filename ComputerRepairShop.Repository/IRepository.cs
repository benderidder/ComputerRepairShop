using ComputerRepairShop.Domain;

namespace ComputerRepairShop.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T? Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
