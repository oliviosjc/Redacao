using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Redacao.Application.DTOs.Usuario.Identity
{
    public class UsuarioLogadoMiddlewareModel
    {
        public UsuarioLogadoMiddlewareModel()
        {

        }

        public UsuarioLogadoMiddlewareModel(HttpContext _context)
        {
            this.Id = Convert.ToInt32(_context.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        public Int32 Id { get; set; }

        public Int32 OrganizacaoId { get; set; }

        public bool EAdministrador { get; set; }
    }
}
