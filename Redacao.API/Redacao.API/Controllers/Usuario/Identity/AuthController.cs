using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.Handlers.Usuario.Identity;
using System;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Usuario.Identity
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IMediator mediator,
                              ILogger<AuthController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] CriarUsuarioCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpPost("logar")]
        public async Task<IActionResult> Logar([FromBody] RealizarLoginUsuarioCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpPost("recuperar-senha")]
        public async Task<IActionResult> RecuperarSenha(RecuperarSenhaCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpPost("resetar-senha")]
        public async Task<IActionResult> ResetarSenha(ResetarSenhaCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpPost("desabilitar")]
        public async Task<IActionResult> DesabilitarUsuario(DesabilitarUsuarioCommand command)
        {
            try
            {
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
