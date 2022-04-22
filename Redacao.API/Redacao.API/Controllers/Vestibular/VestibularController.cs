using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Vestibular;
using Redacao.Application.DTOs;
using Redacao.Application.Queries.Vestibular;
using Redacao.Domain.Entidades.Vestibular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Vestibular
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class VestibularController : BaseController<VestibularVestibular>
    {
        private readonly IMediator _mediator;

        public VestibularController(IMediator mediator, ILogger<VestibularVestibular> logger) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarVestibularCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<VestibularVestibular>(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] EditarVestibularCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<VestibularVestibular>(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodosVestibularesQuery query = new BuscarTodosVestibularesQuery();
                query.Paginacao = paginacao;

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<VestibularVestibular>(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Int32 id)
        {
            try
            {
                BuscarVestibularPorIdQuery query = new BuscarVestibularPorIdQuery();
                query.Id = id;

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<VestibularVestibular>(ex);
            }
        }
    }
}
