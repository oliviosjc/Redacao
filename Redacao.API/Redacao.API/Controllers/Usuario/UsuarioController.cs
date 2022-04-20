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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController 
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsuarioUsuario> _logger;


        public UsuarioController(IMediator mediator,
                                 ILogger<UsuarioUsuario> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("{id}/organizacoes")]
        public async Task<IActionResult> VincularOrganizacoesAUsuario(Int32 id, [FromBody] VincularOrganizacoesAUsuarioCommand command)
        {
            try
            {
                command.UsuarioId = id;
                command.UsuarioLogado = await this.BuscarUsuarioLogado();
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }
    }
}
