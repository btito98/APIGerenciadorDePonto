using GerenciadorDePonto.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGerenciadorDePonto.Model
{
    public class Perfil : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime dataRegistro { get; set; }
        public Guid FKEmpresa { get; set; }
    }
}
