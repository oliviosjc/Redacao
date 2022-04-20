using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Usuario.Auth
{
    public class BuscarTodasRolesQuery : IRequest<ResponseViewModel<List<Role>>>
    {
        public BuscarTodasRolesQuery()
        {

        }

        public UsuarioLogadoMiddlewareModel UsuarioLogado { get; set; }
    }
}
