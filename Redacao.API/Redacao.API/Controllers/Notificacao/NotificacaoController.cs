using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Notificacao;
using Redacao.Application.DTOs;
using Redacao.Application.Queries.Notificacao;
using Redacao.Domain.Entidades.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Notificacao
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class NotificacaoController : BaseController<NotificacaoNotificacao>
    {
        private readonly IMediator _mediator;
        public NotificacaoController(IMediator mediator,
                                     ILogger<NotificacaoNotificacao> logger) : base(logger)
        {
            _mediator = mediator;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "SYSADMIN")]
        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodasNotificacoesQuery query = new BuscarTodasNotificacoesQuery(paginacao);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<NotificacaoNotificacao>(ex);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "SYSADMIN")]
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Int32 id)
        {
            try
            {
                BuscarNotificacaoPorIdQuery query = new BuscarNotificacaoPorIdQuery(id);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<NotificacaoNotificacao>(ex);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "SYSADMIN")]
        [HttpPost]
        public async Task<IActionResult> Criar(CriarNotificacaoCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<NotificacaoNotificacao>(ex);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "SYSADMIN")]
        [HttpPut]
        public async Task<IActionResult> Editar(EditarNotificacaoCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<NotificacaoNotificacao>(ex);
            }
        }
    }
}
