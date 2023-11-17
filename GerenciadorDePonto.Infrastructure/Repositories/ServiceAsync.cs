using AutoMapper;
using GerenciadorDePonto.Domain.Model;
using GrenciadorDePonto.Application.DTOs;
using GrenciadorDePonto.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePonto.Infrastructure.Repositories
{
    public class ServiceAsync<TEntity, TDto> : IServiceAsync<TEntity, TDto>
        where TDto : EntityDto where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public ServiceAsync(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(TDto tDto)
        {
            var entity = _mapper.Map<TEntity>(tDto);
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid? id)
        {
            var entity = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity.Result);
        }

        public IEnumerable<TDto> GetAll(Expression<Func<TDto, bool>> expression = null)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            return _repository.GetAllAsync(predicate).Select(x => _mapper.Map<TDto>(x));
        }

        public async Task<TDto> GetByIdAsync(Guid? id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task UpdateAsync(Guid id, TDto tDto)
        {
            var entity = _mapper.Map<TEntity>(tDto);
            await _repository.UpdateAsync(id,entity);
        }
    }
}
