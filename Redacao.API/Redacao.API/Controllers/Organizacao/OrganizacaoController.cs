using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Organizacao;
using Redacao.Application.DTOs;
using Redacao.Application.Queries.Organizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Organizacao
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class OrganizacaoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrganizacaoController> _logger;

        public OrganizacaoController(IMediator mediator, ILogger<OrganizacaoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarOrganizacaoCommand command)
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
        public async Task<IActionResult> Editar([FromBody] EditarOrganizacaoCommand command)
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

        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] RequestPaginacao paginacao )
        {
            try
            {
                BuscarTodasOrganizacoesQuery query = new BuscarTodasOrganizacoesQuery(paginacao);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch(Exception ex)
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
                BuscarOrganizacaoPorIdQuery query = new BuscarOrganizacaoPorIdQuery(id);

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
