using APIGerenciadorDePonto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIGerenciadorDePonto.Data.MapEntities
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Nome).IsRequired();
            builder.Property(f => f.dataNascimento).IsRequired();
            builder.Property(f => f.CPF).IsRequired();
            builder.Property(f => f.Email).IsRequired();
            builder.Property(f => f.cargaHoraria).IsRequired();
            builder.HasOne(f => f.tipoPerfil).WithOne().HasPrincipalKey<Perfil>(p => p.Id).HasForeignKey<Funcionario>(f => f.tipoPerfil);
            builder.HasOne(f => f.idEndereco).WithOne().HasPrincipalKey<Endereco>(e => e.Id).HasForeignKey<Funcionario>(f => f.idEndereco);
            builder.HasOne (f => f.idEmpresa).WithOne().HasPrincipalKey<Empresa>(e => e.Id).HasForeignKey<Funcionario>(f => f.idEmpresa);
        }
    }
}
