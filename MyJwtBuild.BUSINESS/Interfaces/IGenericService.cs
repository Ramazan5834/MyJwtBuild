using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJwtBuild.BUSINESS.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class, new()
    {
        Task<TEntity> AddWithRetObjectAsync(TEntity entity);
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
    }
}
