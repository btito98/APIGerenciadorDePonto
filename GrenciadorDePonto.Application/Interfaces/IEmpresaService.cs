using APIGerenciadorDePonto.Model;
using GrenciadorDePonto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.Interfaces
{
    public interface IEmpresaService : IServiceAsync<Empresa, EmpresaDTO>
    {
        
    }
}
