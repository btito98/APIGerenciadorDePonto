using APIGerenciadorDePonto.Model;
using GrenciadorDePonto.Application.DTOs;
using GrenciadorDePonto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDePontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IService<Empresa, EmpresaDTO> _empresaService;
        public EmpresaController(IService<Empresa, EmpresaDTO> empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("ListarEmpresas")] 
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var empresas =  _empresaService.GetAll();
                if (empresas == null) return NotFound();
                return Ok(empresas);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao listar empresas");
            }
        }

        [HttpPost("AdicionarEmpresa")]
        public async Task<ActionResult> Post([FromBody] EmpresaDTO empresaDTO)
        {
            try
            {
                empresaDTO.Email = empresaDTO.Email.ToLower();
                await _empresaService.AddAsync(empresaDTO);
                return Ok("Empresa cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{empresaId}")]
        public async Task<ActionResult> GetById([FromRoute] Guid empresaId)
        {
            try
            {
                var empresa = await _empresaService.GetByIdAsync(empresaId);
                if (empresa == null) return NotFound();
                return Ok(empresa);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao obter empresa");
            }
        }

        [HttpPut("{empresaId}")]
        public async Task<ActionResult> Update([FromRoute] Guid empresaId, [FromBody]EmpresaDTO empresaDTO)
        {
            try
            {
                await _empresaService.UpdateAsync(empresaId, empresaDTO);
                return Ok("Empresa atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{empresaId}")]
        public async Task<ActionResult> Delete(Guid empresaId)
        {
            try
            {
                await _empresaService.DeleteAsync(empresaId);
                return Ok("Empresa excluída com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
