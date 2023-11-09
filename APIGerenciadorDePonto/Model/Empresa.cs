namespace APIGerenciadorDePonto.Model
{
    public class Empresa
    {
        public Guid Id { get; set; }
        public string razaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public Endereco idEndereco { get; set; }

    }
}
