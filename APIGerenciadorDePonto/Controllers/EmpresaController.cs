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

        //[HttpPost("AdicionarEmpresa")]
        //public async Task<ActionResult> Post([FromBody] EmpresaDTO empresaDTO)
        //{
        //    try
        //    {
        //        await _empresaService.AddEmpresa(empresaDTO);
        //        return Ok("Empresa cadastrada com sucesso");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}




    }
}
