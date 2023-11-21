using APIGerenciadorDePonto.Model;
using AutoMapper;
using GrenciadorDePonto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePonto.Application.DTOs
{
    public class RegistroDePontoDto : EntityDto
    {
        public DateTime? dataHoraEntrada { get; set; }
        public DateTime? dataHoraSaida { get; set; }
        public Guid FKFuncionario { get; set; }
        public double Latitude { get; set; }
        public double Logintude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegistroDePontoDto, RegistroPonto>().ReverseMap();
        }
    }
}
