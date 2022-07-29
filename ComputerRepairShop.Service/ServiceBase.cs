using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;
using Microsoft.Extensions.Logging;

namespace ComputerRepairShop.Service
{
    public class ServiceBase<T> : IService<T> where T : EntityBase
    {
        protected readonly ILogger<ServiceBase<T>> _logger;
        private readonly IRepository<T> _repository;

        public ServiceBase(ILogger<ServiceBase<T>> logger, IRepository<T> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            _logger.LogInformation("Get all");
            return _repository.GetAll();
        }

        public T Get(long id)
        {
            _logger.LogInformation("Get by id");
            try
            {
                var entity = _repository.Get(id);

                if (entity != null)
                {
                    return entity;
                }
                else
                {
                    throw new ArgumentException($"No entity found for id {id}");
                }
            } 
            catch(Exception ex)
            {
                _logger.LogError("Get failed: {message}", ex.Message);
                throw;
            }
        }

        public void Save(T entity)
        {
            _logger.LogInformation("Save entity");
            if (entity == null) throw new ArgumentException($"No entity was provided to save");

            if (entity.Id == 0)
            {
                _repository.Insert(entity);
            }
            else
            {
                _repository.Update(entity);
            }
        }

        public void Delete(T entity)
        {
            _logger.LogInformation("Delete entity");
            if (entity == null) throw new ArgumentException($"No entity was provided to delete");

            _repository.Delete(entity);
        }
    }
}