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
    public class EmpresaService : IService<Empresa, EmpresaDTO>
    {
        private IRepository<Empresa> _empresaRepository;
        private readonly IMapper _mapper;
        public EmpresaService(IRepository<Empresa> empresaRepository, IMapper mapper)
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

        public async Task<EmpresaDTO> GetByIdAsync(Guid? id)
        {
            var empresa = await _empresaRepository.GetByIdAsync(id);
            return _mapper.Map<EmpresaDTO>(empresa);
        }

        public async Task AddAsync(EmpresaDTO tDto)
        {
            var empresa = _mapper.Map<Empresa>(tDto);
            await _empresaRepository.AddAsync(empresa);
        }

        public async Task UpdateAsync(Guid id, EmpresaDTO tDto)
        {
            tDto.Id = id;
            var empresa = _mapper.Map<Empresa>(tDto);
            await _empresaRepository.UpdateAsync(id, empresa);
        }

        public async Task DeleteAsync(Guid? id)
        {
            var empresa = _empresaRepository.GetByIdAsync(id);
            await _empresaRepository.DeleteAsync(empresa.Result); 
        }
    }
}
