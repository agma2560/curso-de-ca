using CLAcademy.Application.Interfaces;
using CLAcademy.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CLAcademy.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> 
        : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AcademyDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AcademyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
