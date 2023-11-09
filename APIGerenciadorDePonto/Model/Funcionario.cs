namespace APIGerenciadorDePonto.Model
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public int cargaHoraria { get; set; }
        public Perfil tipoPerfil { get; set; }
        public Endereco idEndereco { get; set; }
        public Empresa idEmpresa { get; set; }

    }
}
