using GrenciadorDePonto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaDTO>> GetAllEmpresas();
        Task<EmpresaDTO> GetEmpresaById(Guid? id);
        Task AddEmpresa(EmpresaDTO empresaDTO);
        Task UpdateEmpresa(EmpresaDTO empresaDTO);
        Task DeleteEmpresa(Guid? id);
    }
}
