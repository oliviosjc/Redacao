using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class GerarTokenUsuarioCommandHandler : IRequestHandler<GerarTokenUsuarioCommand, string>
    {
        private readonly UserManager<UsuarioUsuario> _userManager;
        public GerarTokenUsuarioCommandHandler(UserManager<UsuarioUsuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(GerarTokenUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _userManager.FindByEmailAsync(request.Email);

            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaims(await _userManager.GetClaimsAsync(usuario));

            var claims = new Claim[]
            {
                new Claim("USUARIOID", usuario.Id.ToString())
            }.ToList();

            var roles = await _userManager.GetRolesAsync(usuario);

            AddRolesToClaims(claims, roles);

            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("7414c2835b3fc16b956a8873777ad181b80a747d153976df49b0140d38882a26a8d4e16cceab74612bfd24ac64c61e4043cf242dacb0aaffaaa94ef3837644b2");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = "REDACAO",
                Audience = "http://localhost",
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        private void AddRolesToClaims(List<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }
        }
    }
}
