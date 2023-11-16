using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetByIdAsync(Guid? id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
