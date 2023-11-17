using APIGerenciadorDePonto.Model;
using GrenciadorDePonto.Application.DTOs;
using GrenciadorDePonto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDePontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IServiceAsync<Funcionario, FuncionarioDTO> _funcionarioService;
        public FuncionarioController(IServiceAsync<Funcionario, FuncionarioDTO> funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet("ListarFuncionarios/{empresaId}")]
        public async Task<ActionResult> GetAll([FromRoute] Guid empresaId)
        {
            try
            {
                var funcionarios = _funcionarioService.GetAll().Where(f => f.FKEmpresa == empresaId);
                if (funcionarios == null) return NotFound();
                return Ok(funcionarios);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao listar funcionários");
            }
        }

        [HttpPost("AdicionarFuncionario/{empresaId}/{perfilId}")]
        public async Task<ActionResult> Post([FromRoute] Guid empresaId, [FromRoute] Guid perfilId,[FromBody] FuncionarioDTO funcionarioDTO)
        {
            try
            {
                funcionarioDTO.FKEmpresa = empresaId;
                funcionarioDTO.FKPerfil = perfilId;
                await _funcionarioService.AddAsync(funcionarioDTO);
                return Ok("Funcionário cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{funcionarioId}/{empresaId}")]
        public async Task<ActionResult> GetById([FromRoute] Guid funcionarioId, [FromRoute] Guid empresaId)
        {
            try
            {
                var funcionario = await _funcionarioService.GetByIdAsync(funcionarioId);
                if (funcionario == null) return NotFound();
                if (funcionario.FKEmpresa != empresaId) return Unauthorized();

                return Ok(funcionario);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao obter funcionario");
            }
        }

        [HttpPut("{funcionarioId}/{empresaId}/{perfilId}")]
        public async Task<ActionResult> Update([FromRoute] Guid funcionarioId, [FromRoute] Guid empresaId, [FromRoute] Guid perfilId, [FromBody]FuncionarioDTO funcionarioDTO)
        {
            try
            {
                var funcionario = await _funcionarioService.GetByIdAsync(funcionarioId);
                if (funcionario.FKEmpresa != empresaId) return Unauthorized();
                funcionarioDTO.FKPerfil = perfilId;
                funcionarioDTO.FKEmpresa = empresaId;
                funcionarioDTO.Id = funcionarioId;
                await _funcionarioService.UpdateAsync(funcionarioId, funcionarioDTO);
                return Ok("Funcionário atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{funcionarioId}/{empresaId}")]
        public async Task<ActionResult> Delete([FromRoute] Guid funcionarioId, [FromRoute] Guid empresaId)
        {
            try
            {
                var funcionario = await _funcionarioService.GetByIdAsync(funcionarioId);
                if (funcionario.FKEmpresa != empresaId) return Unauthorized();
                await _funcionarioService.DeleteAsync(funcionarioId);
                return Ok("Funcionário deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
