using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.DTOs
{
    public class EmpresaDTO
    {
        public Guid Id { get; set; }
        public string razaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
    }
}
