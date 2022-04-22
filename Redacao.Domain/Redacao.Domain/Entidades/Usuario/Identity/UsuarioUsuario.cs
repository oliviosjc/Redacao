using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Notificacao;
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

        public UsuarioUsuario(string nome, string apelido, string cpf, 
                             string rg, DateTime? dataNascimento, string cep,
                             string rua, string bairro, string numero, string complemento,
                             string cidade, string estado, UsuarioSexoEnum? sexo,
                             UsuarioComoConheceuEnum? comoConheceu,
                             string cnpj, TipoUsuarioEnum tipoUsuario, 
                             string numeroCelular, string email, 
                             Int32 quantidadeCorrecoesDisponiveis, Int32 id)
        {
            this.SetarId(id);
            this.SetarCPF(cpf);
            this.SetarCNPJ(cnpj);
            this.SetarRG(rg);
            this.SetarTipoUsuario(tipoUsuario);
            this.SetarNome(nome);
            this.SetarApelido(apelido);
            this.SetarQuantidadeCorrecoesDisponiveis(quantidadeCorrecoesDisponiveis);
            this.SetarDataNascimento(dataNascimento);
            this.SetarCEP(cep);
            this.SetarRua(rua);
            this.SetarBairro(bairro);
            this.SetarNumero(numero);
            this.SetarComplemento(complemento);
            this.SetarCidade(cidade);
            this.SetarEstado(estado);
            this.SetarSexo(sexo);
            this.SetarComoConheceu(comoConheceu);
            this.PhoneNumber = numeroCelular;
            this.Email = email;
            this.NormalizedEmail = email;
            this.UserName = email;
            this.NormalizedUserName = email;
        }

        [Required]
        [StringLength(128)]
        public string Nome { get; private set; }

        [StringLength(55)]
        public string Apelido { get; private set; }

        public DateTime? DataNascimento { get; private set; }

        [StringLength(8)]
        public string CEP { get; private set; }

        [StringLength(128)]
        public string Rua { get; private set; }

        [StringLength(128)]
        public string Bairro { get; private set; }

        [StringLength(5)]
        public string Numero { get; private set; }

        [StringLength(50)]
        public string Complemento { get; private set; }

        [StringLength(128)]
        public string Cidade { get; private set; }

        [StringLength(64)]
        public string Estado { get; private set; }

        public UsuarioSexoEnum? Sexo { get; private set; }

        public UsuarioComoConheceuEnum? ComoConheceu { get; private set; }

        [StringLength(11)]
        public string CPF { get; private set; }

        [StringLength(9)]
        public string RG { get; private set; }

        [StringLength(14)]
        public string CNPJ { get; private set; }

        [Required]
        public TipoUsuarioEnum TipoUsuario { get; private set; }

        [Required]
        public Int32 QuantidadeCorrecoesDisponiveis { get; private set; }

        public virtual ICollection<RedacaoRedacao> Redacoes { get; private set; }

        public virtual ICollection<UsuarioOrganizacao> Organizacoes { get; private set; }

        public virtual ICollection<NotificacaoNotificacao> Notificacoes { get; private set; }

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

        private void SetarApelido(string apelido)
        {
            this.Apelido = apelido;
        }

        private void SetarDataNascimento(DateTime? dataNascimento)
        {
            this.DataNascimento = dataNascimento;
        }

        private void SetarCEP(string cep)
        {
            this.CEP = cep;
        }

        private void SetarRua(string rua)
        {
            this.Rua = rua;
        }

        private void SetarBairro(string bairro)
        {
            this.Bairro = bairro;
        }

        private void SetarNumero(string numero)
        {
            this.Numero = numero;
        }

        private void SetarComplemento(string complemento)
        {
            this.Complemento = complemento;
        }

        private void SetarCidade(string cidade)
        {
            this.Cidade = cidade;
        }

        private void SetarEstado(string estado)
        {
            this.Estado = estado;
        }

        public void SetarSexo(UsuarioSexoEnum? sexo)
        {
            this.Sexo = sexo;
        }

        public void SetarComoConheceu(UsuarioComoConheceuEnum? comoConheceu)
        {
            this.ComoConheceu = comoConheceu;
        }

        private void SetarQuantidadeCorrecoesDisponiveis(Int32 quantidadeCorrecoesDisponiveis)
        {
            this.QuantidadeCorrecoesDisponiveis = quantidadeCorrecoesDisponiveis;
        }

        public void AdicionarQuantidadeCorrecoesDisponiveis(Int32 quantidadeCorrecoesDisponiveis)
        {
            this.QuantidadeCorrecoesDisponiveis += quantidadeCorrecoesDisponiveis;
        }

        public void SubtrairQuantidadeCorrecoesDisponiveis(Int32 quantidadeCorrecoesDisponiveis)
        {
            this.QuantidadeCorrecoesDisponiveis -= quantidadeCorrecoesDisponiveis;
        }

        private void SetarId(Int32 id)
        {
            this.Id = id;
        }

        public  async Task<ValidationResult> ValidaObjeto(UsuarioUsuario objeto)
        {
            UsuarioValidacao validacao = new UsuarioValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
