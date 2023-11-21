using APIGerenciadorDePonto.Model;
using GerenciadorDePonto.Application.DTOs;
using GrenciadorDePonto.Application.Interfaces;
using GrenciadorDePonto.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace GrenciadorDePontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroDePontoController : ControllerBase
    {
        private readonly IService<RegistroPonto, RegistroDePontoDto> _registroDePontoService;
        public RegistroDePontoController(IService<RegistroPonto, RegistroDePontoDto> registroDePontoService)
        {
            _registroDePontoService = registroDePontoService;
        }

        [HttpGet("ListarRegistrosDePonto/{funcionarioId}")]
        public async Task<ActionResult> GetAll([FromRoute] Guid funcionarioId)
        {
            try
            {
                var registrosDePonto = _registroDePontoService.GetAll().Where(f => f.FKFuncionario == funcionarioId);
                if (registrosDePonto == null) return NotFound();
                return Ok(registrosDePonto);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao listar registros de ponto");
            }
        }

        [HttpPost("AdicionarRegistroDePonto/{funcionarioId}")]
        public async Task<ActionResult> Post([FromRoute] Guid funcionarioId, [FromBody] RegistroDePontoDto registroDePontoDto)
        {
            try
            {
                registroDePontoDto.FKFuncionario = funcionarioId;
                await _registroDePontoService.AddAsync(registroDePontoDto);
                return Ok("Registro de ponto cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{registroDePontoId}/{funcionarioId}")]
        public async Task<ActionResult> Put([FromRoute] Guid registroDePontoId, [FromRoute] Guid funcionarioId, [FromBody] RegistroDePontoDto registroDePontoDto)
        {
            try
            {                
                var registroDePonto = await _registroDePontoService.GetByIdAsync(registroDePontoId);
                if (registroDePonto.FKFuncionario != funcionarioId) return Unauthorized();
                registroDePontoDto.Id = registroDePontoId;
                registroDePontoDto.FKFuncionario = funcionarioId;
                await _registroDePontoService.UpdateAsync(registroDePontoId, registroDePontoDto);
                return Ok("Registro de ponto atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
