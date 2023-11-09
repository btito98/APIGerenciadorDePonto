using APIGerenciadorDePonto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIGerenciadorDePonto.Data.MapEntities
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            //mapeie todas as entidades
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.HasOne(p => p.idEmpresa).WithOne().HasPrincipalKey<Empresa>(e => e.Id).HasForeignKey<Perfil>(p => p.idEmpresa);

        }
    }
}
