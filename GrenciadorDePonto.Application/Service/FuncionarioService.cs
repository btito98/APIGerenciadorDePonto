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
    public class FuncionarioService : IServiceAsync<Funcionario, FuncionarioDTO>
    {
        private IRepository<Funcionario> _funcionarioRepository;
        private readonly IMapper _mapper;
        public FuncionarioService(IRepository<Funcionario> funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }
        public IEnumerable<FuncionarioDTO> GetAll(Expression<Func<FuncionarioDTO, bool>> expression = null)
        {
            var funcionarios = _funcionarioRepository.GetAllAsync();
            var funcionariosDTO = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
            return funcionariosDTO;
        }

        public async Task<FuncionarioDTO> GetByIdAsync(Guid? id)
        {
            var funcionario = await _funcionarioRepository.GetByIdAsync(id);
            return _mapper.Map<FuncionarioDTO>(funcionario);
        }

        public async Task AddAsync(FuncionarioDTO tDto)
        {
            var funcionario = _mapper.Map<Funcionario>(tDto);
            await _funcionarioRepository.AddAsync(funcionario);
        }

        public async Task UpdateAsync(Guid id, FuncionarioDTO tDto)
        {
            tDto.Id = id;
            var funcionario = _mapper.Map<Funcionario>(tDto);
            await _funcionarioRepository.UpdateAsync(id, funcionario);
        }

        public async Task DeleteAsync(Guid? id)
        {
            var funcionario = _funcionarioRepository.GetByIdAsync(id);
            await _funcionarioRepository.DeleteAsync(funcionario.Result);
        }
    }
}
