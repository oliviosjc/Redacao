using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Domain.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Redacao.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<B> : ControllerBase where B : class
    {
        private readonly ILogger<B> _logger;

        public BaseController(ILogger<B> logger)
        {
            _logger = logger;
        }

        [ApiExplorerSettings(IgnoreApi = true)]

        public async Task<IActionResult> RetornoBase<T>(ResponseViewModel<T> model) where T : class
        {
            switch (model.HttpStatusCode)
            {
                case HttpStatusCode.OK:
                    {
                        return await Task.FromResult(Ok(model));
                    }

                case HttpStatusCode.BadRequest:
                    {
                        return await Task.FromResult(BadRequest(model));
                    }

                case HttpStatusCode.NoContent:
                    {
                        return await Task.FromResult(NoContent());
                    }

                case HttpStatusCode.UnprocessableEntity:
                    {
                        return await Task.FromResult(UnprocessableEntity(model));
                    }

                default:
                    {
                        return await Task.FromResult(StatusCode(500));
                    }
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> RetornoBase<T>(Exception ex)
        {
            _logger.LogCritical(ex.Message);
            return await Task.FromResult(StatusCode(500));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public Task<UsuarioLogadoMiddlewareModel> BuscarUsuarioLogado()
        {
            UsuarioLogadoMiddlewareModel usuarioLogado = new UsuarioLogadoMiddlewareModel();

            //usuarioLogado.OrganizacaoId = Convert.ToInt32(User.Claims.FirstOrDefault(f => f.Type.ToUpper() is "ORGANIZACAOID").Value);
            usuarioLogado.Id = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Task.FromResult(usuarioLogado);
        }
    }
}
