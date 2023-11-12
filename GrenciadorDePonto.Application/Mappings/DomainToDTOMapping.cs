using APIGerenciadorDePonto.Model;
using AutoMapper;
using GrenciadorDePonto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
        }
    }
}
