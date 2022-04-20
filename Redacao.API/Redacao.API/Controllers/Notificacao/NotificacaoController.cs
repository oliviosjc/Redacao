using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.DTOs;
using Redacao.Application.Queries.Notificacao;
using Redacao.Domain.Entidades.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Notificacao
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotificacaoNotificacao> _logger;
        public NotificacaoController(IMediator mediator,
                                     ILogger<NotificacaoNotificacao> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodasNotificacoesQuery query = new BuscarTodasNotificacoesQuery();
                query.Paginacao = paginacao;

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Int32 id)
        {
            try
            {
                BuscarNotificacaoPorIdQuery query = new BuscarNotificacaoPorIdQuery();
                query.Id = id;

                var resultado = await _mediator.Send(query);

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
