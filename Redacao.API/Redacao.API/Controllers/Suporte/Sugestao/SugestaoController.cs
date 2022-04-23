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
    public class SugestaoController : BaseController<SugestaoSugestao>
    {
        private readonly IMediator _mediator;
        public SugestaoController(IMediator mediator,
                                  ILogger<SugestaoSugestao> logger) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarSugestaoCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<SugestaoSugestao>(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar(EditarSugestaoCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<SugestaoSugestao>(ex);
            }
        }

        [HttpPost("responder")]
        public async Task<IActionResult> Responder(ResponderSugestaoCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<SugestaoSugestao>(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodasSugestoesQuery query = new BuscarTodasSugestoesQuery(paginacao);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<SugestaoSugestao>(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Int32 id)
        {
            try
            {
                BuscarSugestaoPorIdQuery query = new BuscarSugestaoPorIdQuery(id);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<SugestaoSugestao>(ex);
            }
        }
    }
}
