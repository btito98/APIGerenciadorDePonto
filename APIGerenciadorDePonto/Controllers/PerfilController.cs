using APIGerenciadorDePonto.Model;
using GrenciadorDePonto.Application.DTOs;
using GrenciadorDePonto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrenciadorDePontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IService<Perfil, PerfilDto> _perfilService;
        public PerfilController(IService<Perfil, PerfilDto> perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpGet("ListarPerfis/{empresaId}")]
        public async Task<ActionResult> GetAll([FromRoute] Guid empresaId)
        {
            try
            {
                var perfis = _perfilService.GetAll().Where(p => p.FkEmpresa == empresaId);
                if (perfis == null) return NotFound();
                return Ok(perfis);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao listar perfis");
            }
        }

        [HttpPost("AdicionarPerfil/{empresaId}")]
        public async Task<ActionResult> Post([FromRoute]Guid empresaId, [FromBody] PerfilDto perfilDto)
        {
            try
            {
                perfilDto.FkEmpresa = empresaId;
                await _perfilService.AddAsync(perfilDto);
                return Ok("Perfil cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{perfilId}/{empresaId}")]
        public async Task<ActionResult> GetById([FromRoute] Guid perfilId, [FromRoute] Guid empresaId)
        {
            try
            {
                var perfil = await _perfilService.GetByIdAsync(perfilId);
                if (perfil == null) return NotFound();
                if (perfil.FkEmpresa != empresaId) return Unauthorized();

                return Ok(perfil);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao buscar perfil");
            }
        }

        [HttpPut("{perfilId}/{empresaId}")]
        public async Task<ActionResult> Update([FromRoute] Guid perfilId, [FromRoute] Guid empresaId, [FromBody] PerfilDto perfilDto)
        {
            try
            {
                var perfil = await _perfilService.GetByIdAsync(perfilId);
                if (perfil.FkEmpresa != empresaId) return Unauthorized();
                perfilDto.FkEmpresa = empresaId;
                perfilDto.Id = perfilId;
                await _perfilService.UpdateAsync(perfilId ,perfilDto);
                return Ok("Perfil atualizado com sucesso");
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao atualizar perfil");
            }
        }

        [HttpDelete("{perfilId}/{empresaId}")]
        public async Task<ActionResult> Delete([FromRoute] Guid perfilId, [FromRoute] Guid empresaId)
        {
            try
            {
                var perfil = await _perfilService.GetByIdAsync(perfilId);
                if (perfil.FkEmpresa != empresaId) return Unauthorized();
                await _perfilService.DeleteAsync(perfilId);
                return Ok("Perfil deletado com sucesso");
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao deletar perfil");
            }
        }
    }
}
