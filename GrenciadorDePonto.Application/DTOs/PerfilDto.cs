using APIGerenciadorDePonto.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.DTOs
{
    public class PerfilDto : EntityDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid FkEmpresa { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Perfil, PerfilDto>().ReverseMap();
        }
    }
}
