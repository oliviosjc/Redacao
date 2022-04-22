using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Handlers.Categoria;
using Redacao.Application.Handlers.Documento;
using Redacao.Application.Handlers.Notificacao;
using Redacao.Application.Handlers.Organizacao;
using Redacao.Application.Handlers.Redacao;
using Redacao.Application.Handlers.Suporte.Sugestao;
using Redacao.Application.Handlers.Usuario;
using Redacao.Application.Handlers.Usuario.Identity;
using Redacao.Application.Handlers.Vestibular;
using Redacao.Application.Notifications.Usuario.Identity;
using Redacao.Data.Repositorios;
using Redacao.Data.Repositorios.Dapper;
using Redacao.Domain.Repositorios;
using Redacao.Domain.Repositorios.Dapper;
using Redacao.Infra.Cloud.Azure.Services;
using Redacao.Infra.Cloud.Azure.Services.Interfaces;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Cliente.Model;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Consumidor;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Publicador;
using Redacao.Infra.Configuracao;
using Redacao.Infra.Email.Services;

namespace Redacao.API.Helper
{
    public static class InjecaoDependencia
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // REPOSITÓRIO
            services.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            services.AddTransient<IRedacaoRepositorio, RedacaoRepositorio>();

            // HANDLERS
            services.AddMediatR(typeof(Startup));

            services.AddMediatR(typeof(CriarCategoriaCommandHandler));
            services.AddMediatR(typeof(EditarCategoriaCommandHandler));
            services.AddMediatR(typeof(BuscarTodasCategoriasPorTipoQueryHandler));
            services.AddMediatR(typeof(BuscarTodasCategoriasQueryHandler));
            services.AddMediatR(typeof(BuscarCategoriaPorIdQueryHandler));

            services.AddMediatR(typeof(CriarDocumentoCommandHandler));

            services.AddMediatR(typeof(BuscarOrganizacaoPorIdQueryHandler));
            services.AddMediatR(typeof(BuscarTodasOrganizacoesQueryHandler));
            services.AddMediatR(typeof(CriarOrganizacaoCommandHandler));
            services.AddMediatR(typeof(EditarOrganizacaoCommandHandler));

            services.AddMediatR(typeof(AlunoConcluirRedacaoCommandHandler));
            services.AddMediatR(typeof(AlunoConcluirRedacaoNotificationHandler));
            services.AddMediatR(typeof(BuscarRedacaoPorIdQueryHandler));
            services.AddMediatR(typeof(BuscarTemaRedacaoPorIdQueryHandler));
            services.AddMediatR(typeof(BuscarTodasRedacoesDisponiveisCorrecaoQueryHandler));
            services.AddMediatR(typeof(BuscarTodasRedacoesQueryHandler));
            services.AddMediatR(typeof(BuscarTodosTemasRedacaoQueryHandler));
            services.AddMediatR(typeof(CriarRedacaoCommandHandler));
            services.AddMediatR(typeof(CriarTemaRedacaoCommandHandler));
            services.AddMediatR(typeof(EditarRedacaoCommandHandler));
            services.AddMediatR(typeof(EditarTemaRedacaoCommandHandler));
            services.AddMediatR(typeof(InserirDocumentoTemaCommandHandler));
            services.AddMediatR(typeof(ProfessorGarantirCorrecaoCommandHandler));

            services.AddMediatR(typeof(CriarSugestaoCommandHandler));
            services.AddMediatR(typeof(EditarSugestaoCommandHandler));
            services.AddMediatR(typeof(BuscarMinhasSugestoesQueryHandler));
            services.AddMediatR(typeof(BuscarSugestaoPorIdQueryHandler));
            services.AddMediatR(typeof(BuscarTodasSugestoesQueryHandler));
            services.AddMediatR(typeof(ResponderSugestaoCommandHandler));

            services.AddMediatR(typeof(BuscarRolesUsuarioLogadoQueryHandler));
            services.AddMediatR(typeof(BuscarTodasRolesQueryHandler));
            services.AddMediatR(typeof(CriarRoleCommandHandler));
            services.AddMediatR(typeof(CriarUsuarioCommandHandler));
            services.AddMediatR(typeof(CriarUsuarioNotificationHandler));
            services.AddMediatR(typeof(DesabilitarUsuarioCommandHandler));
            services.AddMediatR(typeof(EditarUsuarioCommandHandler));
            services.AddMediatR(typeof(CriarUsuarioNotificationHandler));
            services.AddMediatR(typeof(GerarTokenUsuarioCommandHandler));
            services.AddMediatR(typeof(RealizarLoginUsuarioCommandHandler));
            services.AddMediatR(typeof(RecuperarSenhaCommandHandler));
            services.AddMediatR(typeof(ResetarSenhaCommandHandler));
            services.AddMediatR(typeof(SetarRolesUsuarioCommandHandler));
            services.AddMediatR(typeof(VincularOrganizacoesAUsuarioCommandHandler));

            services.AddMediatR(typeof(BuscarTodosVestibularesQueryHandler));
            services.AddMediatR(typeof(BuscarTodosVestibularesQueryHandler));
            services.AddMediatR(typeof(CriarVestibularCommandHandler));
            services.AddMediatR(typeof(EditarVestibularCommandHandler));
            services.AddMediatR(typeof(VincularVestibularesAoTemaCommandHandler));

            services.AddMediatR(typeof(CriarNotificacaoCommandHandler));
            services.AddMediatR(typeof(EditarNotificacaoCommandHandler));
            services.AddMediatR(typeof(BuscarTodasNotificacoesQueryHandler));
            services.AddMediatR(typeof(BuscarNotificacaoPorIdQueryHandler));
            


            // SERVICES
            services.AddTransient<IAzureBlobStorageService, AzureBlobStorageService>();
            services.AddTransient<IEmailService, EmailService>();

            // FILAS AZURE SERVICE BUS
            services.AddTransient<IMensagemPublicador, MensagemPublicador>();
            ConfiguracaoFila configuracaoFila = configuration.GetSection("Azure:ConfiguracaoFila").Get<ConfiguracaoFila>();
            services.AddSingleton(configuracaoFila);
            services.AddTransient(clienteFileUsuarioCorrecaoDisponivel => new ClienteFilaUsuarioCorrecaoDisponivel(configuration.GetValue<string>("Azure:ConfiguracaoFila:Conexao"), configuration.GetValue<string>("Azure:ConfiguracaoFila:NomeFilaUsuarioCorrecaoDisponivel"), ReceiveMode.PeekLock));
            services.AddHostedService<ConsumidorFilaUsuarioCorrecaoDisponivel>();

            //
            services.AddHttpContextAccessor();

            services.AddTransient(provider => new UsuarioLogadoMiddlewareModel(provider.GetService<IHttpContextAccessor>().HttpContext));
        }
    }
}
