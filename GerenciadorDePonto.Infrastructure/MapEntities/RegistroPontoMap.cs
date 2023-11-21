using APIGerenciadorDePonto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDePonto.Infrastructure.MapEntities
{
    public class RegistroPontoMap : IEntityTypeConfiguration<RegistroPonto>
    {
        public void Configure(EntityTypeBuilder<RegistroPonto> builder)
        {
            builder.HasKey(rp => rp.Id);
            builder.Property(rp => rp.dataHoraEntrada).IsRequired();
            builder.Property(rp => rp.dataHoraSaida).IsRequired();
            builder.Property(rp => rp.Latitude);
            builder.Property(rp => rp.Logintude);
        }

    }
}
