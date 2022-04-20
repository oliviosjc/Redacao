using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Usuario.Identity
{
    public class BuscarRolesUsuarioLogadoQuery : IRequest<ResponseViewModel<List<UsuarioRole>>>
    {
    }
}
