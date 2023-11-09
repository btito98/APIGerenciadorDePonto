namespace APIGerenciadorDePonto.Model
{
    public class Funcionario
    {
        Guid Id { get; set; }
        string Nome { get; set; }
        DateTime dataNascimento { get; set; }
        string CPF { get; set; }
        string Email { get; set; }
        int cargaHoraria { get; set; }        
        Perfil tipoPerfil { get; set; }
        Endereco idEndereco { get; set; }
        Empresa idEmpresa { get; set; }

    }
}
