using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Usuario.Identity
{
    public class BuscarRolesUsuarioLogadoQuery : IRequest<ResponseViewModel<List<string>>>
    {
        public BuscarRolesUsuarioLogadoQuery()
        {

        }
    }
}
