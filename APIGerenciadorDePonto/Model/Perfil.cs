namespace APIGerenciadorDePonto.Model
{
    public class Perfil
    {
        Guid Id { get; set; }
        string Nome { get; set; }
        string Descricao { get; set; }
        DateTime dataRegistro { get; set; }
        Empresa idEmpresa { get; set; } 
    }
}
