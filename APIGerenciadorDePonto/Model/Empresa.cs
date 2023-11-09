namespace APIGerenciadorDePonto.Model
{
    public class Empresa
    {
        Guid Id { get; set; }
        string razaoSocial { get; set; }
        string CNPJ { get; set; }
        string Email { get; set; }
        Endereco idEndereco { get; set; }

    }
}
