using ComputerRepairShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepairShop.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ShopDbContext context;
        private readonly DbSet<T> entities;

        public Repository(ShopDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T? Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Update(entity);            
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
