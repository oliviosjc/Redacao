using MediatR;
using Redacao.Application.Commands.Vestibular;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Vestibular;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Vestibular
{
    public class VincularVestibularesAoTemaCommandHandler : IRequestHandler<VincularVestibularesAoTemaCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<VestibularTema> _repositorioVestibularTema;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public VincularVestibularesAoTemaCommandHandler(IRepositorioGenerico<VestibularTema> repositorioVestibularTema,
                                                        UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioVestibularTema = repositorioVestibularTema;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<string>> Handle(VincularVestibularesAoTemaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vestibularesTemas = await _repositorioVestibularTema.GetAll(wh => wh.Ativo
                                                                                   && wh.TemaId == request.TemaId, null);

                await _repositorioVestibularTema.Delete(vestibularesTemas.ToList());

                var vt = new List<VestibularTema>();

                foreach (var vestibularId in request.VestibularesIds.Distinct())
                {
                    var vestibularTema = new VestibularTema(request.TemaId, vestibularId, 0, _usuarioLogado.Id, DateTime.UtcNow, null, true);
                    var vestibularTemaValidacao = await vestibularTema.ValidaObjeto(vestibularTema);

                    if (vestibularTemaValidacao.IsValid)
                        vt.Add(vestibularTema);
                };

                await _repositorioVestibularTema.Create(vt);
                await _repositorioVestibularTema.Save();

                _repositorioVestibularTema.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "Os vestibulares foram vinculados ao tema.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<string>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<string>.GerarRetorno(ex);
            }
        }
    }
}
