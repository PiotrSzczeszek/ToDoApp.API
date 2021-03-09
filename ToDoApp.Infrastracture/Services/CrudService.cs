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

        public async Task<bool> CreateAsync(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            
            return true;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
