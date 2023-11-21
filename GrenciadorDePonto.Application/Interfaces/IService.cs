using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.Interfaces
{
    public interface IService<TEntity, TDto>
    {
        IEnumerable<TDto> GetAll(Expression<Func<TDto, bool>> expression = null);
        Task<TDto> GetByIdAsync(Guid? id);
        Task AddAsync(TDto tDto);
        Task UpdateAsync(Guid id, TDto tDto);
        Task DeleteAsync(Guid? id);
    }
}
