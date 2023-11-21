using APIGerenciadorDePonto.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.DTOs
{
    public class FuncionarioDTO : EntityDto
    {
        public string Nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public int cargaHoraria { get; set; }
        public Guid FKPerfil { get; set; }
        public Guid FKEmpresa { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
        }
    }
}
