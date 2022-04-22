using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Organizacao;
using Redacao.Application.DTOs;
using Redacao.Application.Queries.Organizacao;
using Redacao.Domain.Entidades.Organizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Organizacao
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class OrganizacaoController : BaseController<OrganizacaoOrganizacao>
    {
        private readonly IMediator _mediator;

        public OrganizacaoController(IMediator mediator, ILogger<OrganizacaoOrganizacao> logger) : base(logger)
        {
            _mediator = mediator;
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
                return await RetornoBase<OrganizacaoOrganizacao>(ex);
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
                return await RetornoBase<OrganizacaoOrganizacao>(ex);
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
                return await RetornoBase<OrganizacaoOrganizacao>(ex);
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
                return await RetornoBase<OrganizacaoOrganizacao>(ex);
            }
        }
    }
}
