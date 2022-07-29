using ComputerRepairShop.Domain;

namespace ComputerRepairShop.Service
{
    internal interface IService<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Save(T entity);
        void Delete(T entity);
    }
}
