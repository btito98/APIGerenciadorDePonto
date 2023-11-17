using GerenciadorDePonto.Infrastructure;
using GerenciadorDePonto.Infrastructure.Repositories;
using GrenciadorDePonto.Application.Interfaces;
using GrenciadorDePonto.Application.Mappings;
using GrenciadorDePonto.Application.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePonto.Shared.IoC
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(IServiceAsync<,>), typeof(ServiceAsync<,>));

            services.AddAutoMapper(typeof(DomainToDTOMapping).Assembly);

        }
    }
}
