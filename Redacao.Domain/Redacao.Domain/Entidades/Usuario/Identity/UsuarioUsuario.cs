using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Enums.Usuario;
using Redacao.Domain.Validacoes.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Redacao.Domain.Entidades.Usuario
{
    public class UsuarioUsuario : IdentityUser<int>
    {
        public UsuarioUsuario()
        {

        }

        public UsuarioUsuario(string nome, string cpf, string rg, string cnpj, TipoUsuarioEnum tipoUsuario, string numeroCelular, string email)
        {
            this.SetarCPF(cpf);
            this.SetarCNPJ(cnpj);
            this.SetarRG(rg);
            this.SetarTipoUsuario(tipoUsuario);
            this.SetarNome(nome);
            this.PhoneNumber = numeroCelular;
            this.Email = email;
            this.NormalizedEmail = email;
            this.UserName = email;
            this.NormalizedUserName = email;
        }

        [StringLength(128)]
        public string Nome { get; private set; }

        [StringLength(11)]
        public string CPF { get; private set; }

        [StringLength(9)]
        public string RG { get; private set; }

        [StringLength(14)]
        public string CNPJ { get; private set; }

        public TipoUsuarioEnum TipoUsuario { get; private set; }

        public virtual ICollection<RedacaoRedacao> Redacoes { get; private set; }

        public virtual ICollection<UsuarioOrganizacao> Organizacoes { get; private set; }

        private void SetarCPF(string cpf)
        {
            this.CPF = cpf;
        }

        private void SetarRG(string rg)
        {
            this.RG = rg;
        }

        private void SetarCNPJ(string cnpj)
        {
            this.CNPJ = cnpj;
        }

        private void SetarTipoUsuario(TipoUsuarioEnum tipoUsuario)
        {
            this.TipoUsuario = tipoUsuario;
        }

        private void SetarNome(string nome)
        {
            this.Nome = nome;
        }

        public  async Task<ValidationResult> ValidaObjeto(UsuarioUsuario objeto)
        {
            UsuarioValidacao validacao = new UsuarioValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
