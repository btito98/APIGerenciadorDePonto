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

        [HttpPost("AdicionarEmpresa")]
        public async Task<ActionResult> Post([FromBody] EmpresaDTO empresaDTO)
        {
            try
            {
                await _empresaService.AddEmpresa(empresaDTO);
                return Ok("Empresa cadastrada com sucesso");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao cadastrar empresa");
            }
        }




    }
}
