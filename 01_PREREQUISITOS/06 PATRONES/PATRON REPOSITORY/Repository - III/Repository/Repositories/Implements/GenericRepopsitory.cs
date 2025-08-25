
using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace Repository.Repositories.Implements
{
    public class GenericRepopsitory<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly SchoolContext _context;

        public GenericRepopsitory(SchoolContext schoolContext)
        {
            _context = schoolContext;
        }

        public async Task DeleteById(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("Entidad nula");
            
            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"La entidad con ID {id} no fue encontrada.");
            }
            return entity;
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
