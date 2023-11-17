using GerenciadorDePonto.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGerenciadorDePonto.Model
{
    public class Funcionario : Entity
    {
        public string Nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public int cargaHoraria { get; set; }
        public Guid FKPerfil { get; set; }
        public Guid FKEmpresa { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Empresa Empresa { get; set; }

    }
}
