using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class CriarRoleCommandHandler : IRequestHandler<CriarRoleCommand, ResponseViewModel<string>>
    {
        private readonly RoleManager<Role> _roleManager;

        public CriarRoleCommandHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ResponseViewModel<string>> Handle(CriarRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _roleManager.FindByNameAsync(request.Nome.ToUpper());

                if(role != null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Já existe uma role cadastrada com este nome :/ Tente novamente.");

                role = new Role
                {
                    Name = request.Nome.ToUpper(),
                    NormalizedName = request.Nome.ToUpper()
                };

                await _roleManager.CreateAsync(role);

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "A role foi criada com sucesso!");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<string>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<string>.GerarRetorno(ex);
            }
        }
    }
}
