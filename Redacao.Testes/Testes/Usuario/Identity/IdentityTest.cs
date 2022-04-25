using Bogus;
using MediatR;
using Moq;
using Redacao.Application.Commands.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Redacao.Testes.Usuario.Identity
{
    public class IdentityTest
    {
        [Fact]
        public async void CriarUsuarioCommandHandlerTest()
        {
            var mediator = new Mock<IMediator>();

            var criarUsuarioCommand = new Faker<CriarUsuarioCommand>()
                .RuleFor(u => u.Nome, (f, u) => f.Name.FullName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Nome))
                .RuleFor(u => u.NumeroCelular, (f, u) => f.Person.Phone)
                .RuleFor(u => u.Senha, (f, u) => f.Internet.Password())
                .RuleFor(u => u.RepetirSenha, (f, u) => u.Senha)
                .RuleFor(u => u.CodigoExterno, (f, u) => Guid.NewGuid());
        }
    }
}
