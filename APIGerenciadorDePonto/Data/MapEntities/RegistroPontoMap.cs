using APIGerenciadorDePonto.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIGerenciadorDePonto.Data.MapEntities
{
    public class RegistroPontoMap : IEntityTypeConfiguration<RegistroPonto>
    {
        public void Configure(EntityTypeBuilder<RegistroPonto> builder)
        {
            builder.HasKey(rp => rp.Id);
            builder.Property(rp => rp.dataHoraEntrada).IsRequired();
            builder.Property(rp => rp.dataHoraSaida).IsRequired();
            builder.HasOne(rp => rp.idFuncionario).WithOne().HasPrincipalKey<Funcionario>(f => f.Id).HasForeignKey<RegistroPonto>(rp => rp.idFuncionario);
            builder.HasOne(rp => rp.idEmpresa).WithOne().HasPrincipalKey<Empresa>(e => e.Id).HasForeignKey<RegistroPonto>(rp => rp.idEmpresa);                    
        }
    }
}
