using APIGerenciadorDePonto.Model;
using AutoMapper;
using GrenciadorDePonto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrenciadorDePonto.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(t => typeof(EntityDto).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface).ToList();            

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }        
        }        
    }
}
