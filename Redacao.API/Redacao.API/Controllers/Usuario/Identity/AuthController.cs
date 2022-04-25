using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.Handlers.Usuario.Identity;
using Redacao.Application.Queries.Usuario.Auth;
using Redacao.Application.Queries.Usuario.Identity;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Usuario.Identity
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class AuthController : BaseController<UsuarioUsuario>
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator,
                              ILogger<UsuarioUsuario> logger) : base(logger)
        {
            _mediator = mediator;
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
                return await RetornoBase<UsuarioUsuario>(ex);
            }
        }

        [HttpPost("confirmar-registro")]
        public async Task<IActionResult> ConfirmarRegistro([FromBody] ConfirmarRegistroUsuarioCommand command)
        {
            try
            {
                try
                {
                    var resultado = await _mediator.Send(command);

                    return await RetornoBase(resultado);
                }
                catch (Exception ex)
                {
                    return await RetornoBase<UsuarioUsuario>(ex);
                }
            }
            catch(Exception ex)
            {
                return await RetornoBase<UsuarioUsuario>(ex);
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
                return await RetornoBase<UsuarioUsuario>(ex);
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
                return await RetornoBase<UsuarioUsuario>(ex);
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
                return await RetornoBase<UsuarioUsuario>(ex);
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
                return await RetornoBase<UsuarioUsuario>(ex);
            }
        }

        [HttpGet("roles")]
        public async Task<IActionResult> BuscarRoles()
        {
            try
            {
                BuscarTodasRolesQuery query = new BuscarTodasRolesQuery();

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<UsuarioUsuario>(ex);
            }
        }

        [HttpPost("role")]
        public async Task<IActionResult> CriarRole([FromBody] CriarRoleCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<UsuarioUsuario>(ex);
            }
        }

        [HttpGet("usuario/roles")]
        public async Task<IActionResult> BuscarRolesUsuario()
        {
            try
            {
                BuscarRolesUsuarioLogadoQuery query = new BuscarRolesUsuarioLogadoQuery();

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<UsuarioUsuario>(ex);
            }
        }

        [HttpPost("usuario/roles")]
        public async Task<IActionResult> SetarRolesUsuario([FromBody] List<string> roles)
        {
            try
            {
                SetarRolesUsuarioCommand command = new SetarRolesUsuarioCommand(roles);

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
