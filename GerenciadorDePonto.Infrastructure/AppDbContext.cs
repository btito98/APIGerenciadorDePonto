using APIGerenciadorDePonto.Model;
using GerenciadorDePonto.Infrastructure.MapEntities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDePonto.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<RegistroPonto> RegistrosPonto { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new RegistroPontoMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
