using System.ComponentModel.DataAnnotations.Schema;

namespace APIGerenciadorDePonto.Model
{
    public class Empresa
    {
        public Guid Id { get; set; }
        public string razaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public virtual List<Funcionario> Funcionarios { get; set; }

    }
}
