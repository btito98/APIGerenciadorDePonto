using APIGerenciadorDePonto.Model;
using AutoMapper;
using GrenciadorDePonto.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.DTOs
{
    public class EmpresaDTO : EntityDto
    {
        public string razaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Empresa, EmpresaDTO>().ReverseMap();
        }
    }
}
