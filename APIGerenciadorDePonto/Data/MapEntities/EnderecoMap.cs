using APIGerenciadorDePonto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIGerenciadorDePonto.Data.MapEntities
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CEP).IsRequired();
            builder.Property(e => e.Bairro).IsRequired();
            builder.Property(e => e.Cidade).IsRequired();
            builder.Property(e => e.Estado).IsRequired();
            builder.Property(e => e.Numero).IsRequired();
            builder.Property(e => e.Complemento);
        }
    }
}
