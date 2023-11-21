using APIGerenciadorDePonto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDePonto.Infrastructure.MapEntities
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
            builder.HasOne(f => f.Perfil).WithMany().HasForeignKey(f => f.FKPerfil);
            builder.HasOne(f => f.Empresa).WithMany().HasForeignKey(f => f.FKEmpresa);

        }
    }
}
