using APIGerenciadorDePonto.Data.MapEntities;
using APIGerenciadorDePonto.Model;
using Microsoft.EntityFrameworkCore;

namespace APIGerenciadorDePonto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {                
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<RegistroPonto> RegistrosPonto { get; set; }
        public DbSet<Perfil> perfils { get; set; }
        public DbSet<Endereco> enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new RegistroPontoMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            base.OnModelCreating(modelBuilder);            
        }
    }
}
