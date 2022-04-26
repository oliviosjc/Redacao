using Bogus;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Moq;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.Handlers.Usuario.Identity;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Repositorios;
using Redacao.Testes.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace Redacao.Testes.Usuario.Identity
{
    public class IdentityTest
    {
        [Fact]
        public async void CriarUsuarioPFCommandHandlerTest()
        {
            var mediator = new Mock<IMediator>();
            var mockStore = Mock.Of<IUserStore<UsuarioUsuario>>();
            var mockUserManager = new Mock<UserManager<UsuarioUsuario>>(mockStore, null, null, null, null, null, null, null, null);
            var mockRepositorioOrganizacao = new Mock<IRepositorioGenerico<OrganizacaoOrganizacao>>();
            var random = new Random();

            var rg = random.Next(100000000, 999999999);
            var fakeCriarUsuarioCommand = new Faker<CriarUsuarioCommand>("pt_BR")
                .RuleFor(u => u.Nome, (f, u) => f.Name.FullName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Nome))
                .RuleFor(u => u.NumeroCelular, (f, u) => f.Person.Phone)
                .RuleFor(u => u.Senha, (f, u) => f.Internet.Password())
                .RuleFor(u => u.RepetirSenha, (f, u) => u.Senha)
                .RuleFor(u => u.CodigoExterno, (f, u) => Guid.NewGuid())
                .RuleFor(u => u.RG, (f, u) => rg.ToString())
                .RuleFor(u => u.CPF, (f, u) => CPF.GerarCpf())
                .RuleFor(u => u.CNPJ, (f,u) => string.Empty);

            var criarUsuarioCommand = fakeCriarUsuarioCommand.Generate();

            CriarUsuarioCommandHandler handler = new CriarUsuarioCommandHandler(mockRepositorioOrganizacao.Object, mockUserManager.Object, mediator.Object);

            var execucao = await handler.Handle(criarUsuarioCommand, new System.Threading.CancellationToken());

            Assert.Equal(HttpStatusCode.OK, execucao.HttpStatusCode);
        }
    }
}
