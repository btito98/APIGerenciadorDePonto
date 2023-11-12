using APIGerenciadorDePonto.Model;
using GrenciadorDePonto.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePonto.Infrastructure.Repositories
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        private AppDbContext _context;
        public EmpresaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Empresa> AddEmpresaAsync(Empresa empresa)
        {
            try
            {
                _context.Empresas.AddAsync(empresa);
                await _context.SaveChangesAsync();
                return empresa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
