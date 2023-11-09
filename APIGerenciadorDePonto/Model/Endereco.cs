namespace APIGerenciadorDePonto.Model
{
    public class Endereco
    {
        Guid Id { get; set; }
        string Rua { get; set; }
        string Numero { get; set; }
        string Bairro { get; set; }
        string Cidade { get; set; }
        string Estado { get; set; }
        string Cep { get; set; }

    }
}
