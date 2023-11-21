using GerenciadorDePonto.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGerenciadorDePonto.Model
{
    public class Empresa : Entity
    {
        public string razaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public virtual List<Funcionario> Funcionarios { get; set; }
        public virtual List<Perfil> Perfis { get; set; }

    }
}
