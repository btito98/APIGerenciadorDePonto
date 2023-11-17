using APIGerenciadorDePonto.Model;
using GrenciadorDePonto.Application.DTOs;
using GrenciadorDePonto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GernciadorDePontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        public EmpresaController(IEmpresaService empresaService)
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
                await _empresaService.AddAsync(empresaDTO);
                return Ok("Empresa cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var empresa = await _empresaService.GetByIdAsync(id);
                if (empresa == null) return NotFound();
                return Ok(empresa);
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao obter empresa");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody]EmpresaDTO empresaDTO)
        {
            try
            {
                await _empresaService.UpdateAsync(id, empresaDTO);
                return Ok("Empresa atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _empresaService.DeleteAsync(id);
                return Ok("Empresa excluída com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
