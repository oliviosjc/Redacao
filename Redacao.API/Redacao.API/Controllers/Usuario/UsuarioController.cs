using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Usuario;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Usuario
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController<UsuarioUsuario>
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator,
                                 ILogger<UsuarioUsuario> logger) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpPost("{id}/organizacoes")]
        public async Task<IActionResult> VincularOrganizacoesAUsuario(Int32 id, [FromBody] VincularOrganizacoesAUsuarioCommand command)
        {
            try
            {
                command.UsuarioId = id;
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<UsuarioUsuario>(ex);
            }
        }
    }
}
