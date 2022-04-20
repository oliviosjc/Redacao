using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Usuario.Auth;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class BuscarTodasRolesQueryHandler : IRequestHandler<BuscarTodasRolesQuery, ResponseViewModel<List<Role>>>
    {
        private readonly RoleManager<Role> _roleManager;

        public BuscarTodasRolesQueryHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseViewModel<List<Role>>> Handle(BuscarTodasRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var roles = _roleManager.Roles.ToList();

                if(roles.Any())
                    return ResponseReturnHelper<List<Role>>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrada nenhuma role na base de dados :/ Tente novamente.");

                return ResponseReturnHelper<List<Role>>.GerarRetorno(HttpStatusCode.OK, roles, "As roles foram encontradas com sucesso.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<Role>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<Role>>.GerarRetorno(ex);
            }
        }
    }
}
