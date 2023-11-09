namespace APIGerenciadorDePonto.Model
{
    public class RegistroPonto
    {
        public Guid Id { get; set; }
        public DateTime dataHoraEntrada { get; set; }
        public DateTime dataHoraSaida { get; set; }
        public Funcionario idFuncionario { get; set; }
        public Empresa idEmpresa { get; set; }
    }
}
