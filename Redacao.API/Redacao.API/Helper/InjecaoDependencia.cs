using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redacao.Application.Commands;
using Redacao.Application.Handlers.Organizacao;
using Redacao.Application.Handlers.Usuario.Identity;
using Redacao.Data.Repositorios;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Redacao.API.Helper
{
    public static class InjecaoDependencia
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            services.AddMediatR(typeof(CriarUsuarioCommandHandler));
            services.AddMediatR(typeof(RealizarLoginUsuarioCommandHandler));
            services.AddMediatR(typeof(CriarOrganizacaoCommandHandler));
        }
    }
}
