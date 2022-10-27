using Microsoft.EntityFrameworkCore;
using MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Context;
using MyJwtBuild.DATAACCESS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, new()
    {
        private readonly MyJwtBuildContext _context;
        public EfGenericRepository(MyJwtBuildContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddWithRetObjectAsync(TEntity entity)
        {
            var addEntity = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return addEntity.Entity;
        }

        public async Task AddAsync(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
             _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
