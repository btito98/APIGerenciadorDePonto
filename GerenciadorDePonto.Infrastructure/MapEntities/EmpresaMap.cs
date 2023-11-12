using APIGerenciadorDePonto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDePonto.Infrastructure.MapEntities
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.razaoSocial).IsRequired();
            builder.Property(e => e.CNPJ).IsRequired();
            builder.Property(e => e.Email).IsRequired();
            builder.HasMany(e => e.Funcionarios).WithOne(f => f.Empresa);
        }
    }
}
