using GerenciadorDePonto.Domain.Model;
using GerenciadorDePonto.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GrenciadorDePonto.Application.Interfaces;

namespace GerenciadorDePonto.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
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
                _context.Set<T>().Remove(entity);
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
                return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException("Element not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            try
            {
                var existingEntity = await _context.Set<T>().FindAsync(id);

                if (existingEntity != null)
                {
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
                else
                {
                    _context.Update(entity);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   
    }
}
