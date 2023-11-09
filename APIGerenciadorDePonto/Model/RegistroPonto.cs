namespace APIGerenciadorDePonto.Model
{
    public class RegistroPonto
    {
        Guid Id { get; set; }
        DateTime dataHoraEntrada { get; set; }
        DateTime dataHoraSaida { get; set; }
        Funcionario idFuncionario { get; set; }
        Empresa idEmpresa { get; set; }
    }
}
