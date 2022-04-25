using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Documento;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.DTOs;
using Redacao.Application.Handlers.Redacao;
using Redacao.Application.Queries.Redacao;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Enums.Documento;
using Redacao.Domain.Repositorios.Dapper;
using Redacao.Infra.Socket.SignalR.Redacao;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Redacao
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class RedacaoController : BaseController<RedacaoRedacao>
    {
        private readonly IMediator _mediator;
        private readonly IRedacaoRepositorio _redacaoRepositorio;


        public RedacaoController(IMediator mediator, 
                                 ILogger<RedacaoRedacao> logger,
                                 IRedacaoRepositorio redacaoRepositorio) : base(logger)
        {
            _mediator = mediator;
            _redacaoRepositorio = redacaoRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarRedacaoCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<RedacaoRedacao>(ex);
            }
        }

        [HttpPost("{id}/aluno/concluir")]
        public async Task<IActionResult> AlunoConclusao(Int32 id)
        {
            try
            {
                AlunoConcluirRedacaoCommand command = new AlunoConcluirRedacaoCommand(id);

                var resultado = await _mediator.Send(command);
                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<RedacaoRedacao>(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] EditarRedacaoCommand command)
        {
            try
            {
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<RedacaoRedacao>(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodasRedacoesQuery query = new BuscarTodasRedacoesQuery(paginacao);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<RedacaoRedacao>(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Int32 id)
        {
            try
            {
                BuscarRedacaoPorIdQuery query = new BuscarRedacaoPorIdQuery(id);

                var resultado = await _mediator.Send(query);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<RedacaoRedacao>(ex);
            }
        }

        [HttpGet("professor/disponiveis-correcao")]
        public async Task<IActionResult> BuscarDisponiveisCorrecao([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodasRedacoesDisponiveisCorrecaoQuery query = new BuscarTodasRedacoesDisponiveisCorrecaoQuery(paginacao);

                var resultado = await _mediator.Send(query);
                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<RedacaoRedacao>(ex);
            }
        }

        [HttpPost("{id}/professor/corrigir")]
        public async Task<IActionResult> ProfessorCorrigir(Int32 id)
        {
            try
            {
                ProfessorGarantirCorrecaoCommand command = new ProfessorGarantirCorrecaoCommand(id);

                var resultado = await _mediator.Send(command);
                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<RedacaoRedacao>(ex);
            }
        }

        [HttpGet("dapper")]
        public async Task<IActionResult> BuscarDapper()
        {
            var redacoes = await _redacaoRepositorio.Buscar();

            return Ok(redacoes);
        }

        [HttpPost("{id}/documento")]
        public async Task<IActionResult> InserirDocumento(Int32 id, IFormFile arquivo)
        {
            try
            {
                CriarDocumentoCommand command = new CriarDocumentoCommand(arquivo, id, TipoDocumentoEnum.REDACAO);

                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                return await RetornoBase<RedacaoRedacao>(ex);
            }
        }
    }
}
