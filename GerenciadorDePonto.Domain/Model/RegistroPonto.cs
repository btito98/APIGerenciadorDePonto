using GerenciadorDePonto.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGerenciadorDePonto.Model
{
    public class RegistroPonto : Entity
    {
        public DateTime dataHoraEntrada { get; set; }
        public DateTime dataHoraSaida { get; set; }
        [ForeignKey("Funcionario")]
        public Guid FKFuncionario { get; set; }
        public double Latitude { get; set; }
        public double Logintude { get; set; }
    }
}
