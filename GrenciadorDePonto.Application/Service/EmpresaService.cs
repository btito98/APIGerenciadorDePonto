using APIGerenciadorDePonto.Model;
using AutoMapper;
using GrenciadorDePonto.Application.DTOs;
using GrenciadorDePonto.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.Service
{    
    public class EmpresaService : IServiceAsync<Empresa, EmpresaDTO>, IEmpresaService
    {
        private IRepository<Empresa> _empresaRepository;
        private readonly IMapper _mapper;
        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public IEnumerable<EmpresaDTO> GetAll(Expression<Func<EmpresaDTO, bool>> expression = null)
        {
            var empresas = _empresaRepository.GetAllAsync();
            var empresasDTO = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);
            return empresasDTO;
        }

        public Task<EmpresaDTO> GetByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(EmpresaDTO tDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(EmpresaDTO tDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid? id)
        {
            throw new NotImplementedException();
        }
    }
}
