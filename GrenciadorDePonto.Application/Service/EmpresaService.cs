using APIGerenciadorDePonto.Model;
using AutoMapper;
using GrenciadorDePonto.Application.DTOs;
using GrenciadorDePonto.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.Service
{    
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }
        public async Task AddEmpresa(EmpresaDTO empresaDTO)
        {
            var empresaEntity = _mapper.Map<Empresa>(empresaDTO); 
            await _empresaRepository.AddAsync(empresaEntity);
        }

        public Task DeleteEmpresa(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmpresaDTO>> GetAllEmpresas()
        {
            var empresas = _empresaRepository.GetAllAsync();
            return _mapper.Map<Task<IEnumerable<EmpresaDTO>>>(empresas);
        }

        public Task<EmpresaDTO> GetEmpresaById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmpresa(EmpresaDTO empresaDTO)
        {
            throw new NotImplementedException();
        }
    }
}
