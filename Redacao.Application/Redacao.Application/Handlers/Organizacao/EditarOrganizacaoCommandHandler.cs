using MediatR;
using Redacao.Application.Commands.Organizacao;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Organizacao
{
    public class EditarOrganizacaoCommandHandler : IRequestHandler<EditarOrganizacaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<OrganizacaoOrganizacao> _repositorioOrganizacao;

        public EditarOrganizacaoCommandHandler(IRepositorioGenerico<OrganizacaoOrganizacao> repositorioOrganizacao)
        {
            _repositorioOrganizacao = repositorioOrganizacao;
        }

        public async Task<ResponseViewModel<string>> Handle(EditarOrganizacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var organizacao = await _repositorioOrganizacao.Get(org => org.Id == request.Id
                                                           && org.Ativo);
                                                           

                if(organizacao is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "A organização que deseja editar não existe ou você não possui direitos para acessa-la :/");

                organizacao = new OrganizacaoOrganizacao(request.Nome, request.Descricao, request.CorPrimaria, 
                                                         request.CorSecundaria, organizacao.CodigoExterno, 
                                                         request.TipoOrganizacao, organizacao.Id, 
                                                         organizacao.UsuarioCriadorId, organizacao.CriadoEm, 
                                                         DateTime.Now, true);

                var organizacaoValida = await organizacao.ValidaObjeto(organizacao);

                if(!organizacaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(organizacaoValida);

                await _repositorioOrganizacao.Update(organizacao);
                await _repositorioOrganizacao.Save();

                _repositorioOrganizacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooooba... As informações de cabeçalho da organização foram editadas com sucesso :)");
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
