using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Categoria;
using Redacao.Application.Commands.Organizacao;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Queries.Categoria;
using Redacao.Domain.Entidades.Categoria;
using Redacao.Domain.Enums.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Categoria
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class CategoriaController : BaseController<CategoriaCategoria>
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator,
                                   ILogger<CategoriaCategoria> categoria) : base(categoria)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarCategoriaCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<CategoriaCategoria>(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] EditarCategoriaCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<CategoriaCategoria>(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodasCategoriasQuery query = new BuscarTodasCategoriasQuery(paginacao);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<CategoriaCategoria>(ex);

            }
        }

        [HttpGet("tipo/{id}")]
        public async Task<IActionResult> BuscarPorTipo(TipoCategoriaEnum id, [FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodasCategoriasPorTipoQuery query = new BuscarTodasCategoriasPorTipoQuery(id, paginacao);

                return await RetornoBase(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return await RetornoBase<CategoriaCategoria>(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Int32 id)
        {
            try
            {
                BuscarCategoriaPorIdQuery query = new BuscarCategoriaPorIdQuery(id);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<CategoriaCategoria>(ex);
            }
        }
    }
}
