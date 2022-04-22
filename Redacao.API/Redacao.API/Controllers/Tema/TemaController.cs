using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.Commands.Vestibular;
using Redacao.Application.DTOs;
using Redacao.Application.Queries.Redacao;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Tema
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class TemaController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TemaRedacao> _logger;

        public TemaController(IMediator mediator, ILogger<TemaRedacao> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarTemaRedacaoCommand command)
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
        public async Task<IActionResult> Editar([FromBody] EditarTemaRedacaoCommand command)
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

        [HttpPost("{id}/documento")]
        public async Task<IActionResult> InserirDocumento(Int32 id, IFormFile arquivo)
        {
            try
            {
                InserirDocumentoTemaCommand command = new InserirDocumentoTemaCommand(id, arquivo);

                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodosTemasRedacaoQuery query = new BuscarTodosTemasRedacaoQuery(paginacao);

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
                BuscarTemaRedacaoPorIdQuery query = new BuscarTemaRedacaoPorIdQuery(id);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpPost("{id}/vestibulares")]
        public async Task<IActionResult> VincularVestibularesAoTema(Int32 id, [FromBody] VincularVestibularesAoTemaCommand command)
        {
            try
            {
                command.TemaId = id;
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
