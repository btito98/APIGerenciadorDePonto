using APIGerenciadorDePonto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIGerenciadorDePonto.Data.MapEntities
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.razaoSocial).IsRequired();
            builder.Property(e => e.CNPJ).IsRequired();                
            builder.Property(e => e.Email).IsRequired();
            builder.HasOne(e => e.idEndereco).WithOne().HasPrincipalKey<Endereco>(e => e.Id).HasForeignKey<Empresa>(e => e.idEndereco);           
                
        }
    }
}
