using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Services;
using ToDoApp.Data;

namespace ToDoApp.Infrastracture.Services
{
    public class CrudService<TEntity> : ICrudService<TEntity>
        where TEntity : Entity
    {
        public IQueryable<TEntity> GetEntities => _context.Set<TEntity>().AsQueryable();

        private ToDoAppContext _context { get; }

        public CrudService(ToDoAppContext context)
        {
            _context = context;
        }

        public Task<bool> CreateAsync(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            
            return Task.FromResult(true);
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
