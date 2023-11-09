namespace APIGerenciadorDePonto.Model
{
    public class Perfil
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime dataRegistro { get; set; }
        public Empresa idEmpresa { get; set; } 
    }
}
