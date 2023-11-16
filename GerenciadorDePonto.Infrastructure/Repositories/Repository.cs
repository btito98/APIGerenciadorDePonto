using GrenciadorDePonto.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePonto.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;
        protected DbSet<T> _table;
        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _table.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            try
            {
                var result = _context.Set<T>().AsNoTracking();
                if (expression != null)
                    result = result.Where(expression);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(Guid? id)
        {
            try
            {
                return await _table.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task UpdateAsync(T entity)
        {
            try
            {
                _table.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
