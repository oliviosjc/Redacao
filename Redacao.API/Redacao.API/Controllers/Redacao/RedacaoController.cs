using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Redacao.API.Controllers.Base;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.DTOs;
using Redacao.Application.Handlers.Redacao;
using Redacao.Application.Queries.Redacao;
using Redacao.Domain.Entidades.Redacao;
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
    [Route("api/[controller]")]
    [ApiController]
    public class RedacaoController : BaseController
    {
        private static ConcurrentBag<StreamWriter> _clients = new ConcurrentBag<StreamWriter>();
        private readonly IMediator _mediator;
        private readonly ILogger<RedacaoRedacao> _logger;
        private readonly IHubContext<RedacaoHub> _redacaoHub;
        private readonly IRedacaoRepositorio _redacaoRepositorio;


        public RedacaoController(IMediator mediator, 
                                 ILogger<RedacaoRedacao> logger,
                                 IHubContext<RedacaoHub> redacaoHub,
                                 IRedacaoRepositorio redacaoRepositorio)
        {
            _mediator = mediator;
            _logger = logger;
            _redacaoHub = redacaoHub;
            _redacaoRepositorio = redacaoRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarRedacaoCommand command)
        {
            try
            {
                command.UsuarioLogado = await this.BuscarUsuarioLogado();
                var resultado = await _mediator.Send(command);

                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpPost("{id}/aluno/concluir")]
        public async Task<IActionResult> AlunoConclusao(Int32 id)
        {
            try
            {
                AlunoConcluirRedacaoCommand command = new AlunoConcluirRedacaoCommand();
                command.Id = id;
                command.UsuarioLogado = await BuscarUsuarioLogado();

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
        public async Task<IActionResult> Editar([FromBody] EditarRedacaoCommand command)
        {
            try
            {
                command.UsuarioLogado = await this.BuscarUsuarioLogado();
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
                BuscarTodasRedacoesQuery query = new BuscarTodasRedacoesQuery();
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
                BuscarRedacaoPorIdQuery query = new BuscarRedacaoPorIdQuery();
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

        [HttpGet("professor/disponiveis-correcao")]
        public async Task<IActionResult> BuscarDisponiveisCorrecao([FromQuery] RequestPaginacao paginacao)
        {
            try
            {
                BuscarTodasRedacoesDisponiveisCorrecaoQuery query = new BuscarTodasRedacoesDisponiveisCorrecaoQuery();
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

        [HttpPost("{id}/professor/corrigir")]
        public async Task<IActionResult> ProfessorCorrigir(Int32 id)
        {
            try
            {
                ProfessorGarantirCorrecaoCommand command = new ProfessorGarantirCorrecaoCommand();
                command.Id = id;
                command.UsuarioLogado = await BuscarUsuarioLogado();

                var resultado = await _mediator.Send(command);
                return await RetornoBase(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await RetornoBase(ex);
            }
        }

        [HttpGet("dapper")]
        public async Task<IActionResult> BuscarDapper()
        {
            var redacoes = await _redacaoRepositorio.Buscar();

            return Ok(redacoes);
        }
    }
}
