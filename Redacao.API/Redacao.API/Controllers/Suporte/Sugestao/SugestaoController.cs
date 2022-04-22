using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Suporte.Sugestao;
using Redacao.Application.DTOs;
using Redacao.Application.Queries.Suporte.Sugestao;
using Redacao.Domain.Entidades.Suporte.Sugestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Suporte.Sugestao
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class SugestaoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SugestaoSugestao> _logger;

        public SugestaoController(IMediator mediator,
                                  ILogger<SugestaoSugestao> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarSugestaoCommand command)
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

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] EditarSugestaoCommand command)
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

        [HttpGet("minhas-sugestoes")]
        public async Task<IActionResult> BuscarMinhasSugestoes([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarMinhasSugestoesQuery query = new BuscarMinhasSugestoesQuery(paginacao);

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
        public async Task<IActionResult> BuscarSugestaoPorId(Int32 id)
        {
            try
            {
                BuscarSugestaoPorIdQuery query = new BuscarSugestaoPorIdQuery(id);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodasSugestoes([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodasSugestoesQuery query = new BuscarTodasSugestoesQuery(paginacao);

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
