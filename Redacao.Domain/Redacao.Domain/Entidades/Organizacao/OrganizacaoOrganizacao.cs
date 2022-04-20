using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Documento;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Entidades.Vestibular;
using Redacao.Domain.Enums.Organizacao;
using Redacao.Domain.Validacoes.Organizacao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Organizacao
{
    public class OrganizacaoOrganizacao : EntidadeBase
    {
        public OrganizacaoOrganizacao()
        {

        }

        public OrganizacaoOrganizacao(string nome, string descricao, string corPrimaria, 
                                      string corSecundaria, Guid codigoExterno, 
                                      TipoOrganizacaoEnum tipoOrganizacao,
                                      Int32 id, Int32 usuarioCriadorId, DateTime criadoEm, 
                                      DateTime? modificadoEm, bool ativo)
        {
            this.SetarNome(nome);
            this.SetarDescricao(descricao);
            this.SetarCorPrimaria(corPrimaria);
            this.SetarCorSecundaria(corSecundaria);
            this.SetarCodigoExterno(codigoExterno);
            this.SetarTipoOrganizacao(tipoOrganizacao);
            this.SetarId(id);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarAtivo(ativo);
        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string CorPrimaria { get; private set; }

        public string CorSecundaria { get; private set; }

        public Guid CodigoExterno { get; private set; }

        public TipoOrganizacaoEnum TipoOrganizacao { get; private set; }

        public virtual ICollection<UsuarioOrganizacao> Usuarios { get; private set; }

        private void SetarNome(string nome)
        {
            this.Nome = nome;
        }

        private void SetarDescricao(string descricao)
        {
            this.Descricao = descricao;
        }

        private void SetarCorPrimaria(string corPrimaria)
        {
            this.CorPrimaria = corPrimaria;
        }

        private void SetarCorSecundaria(string corSecundaria)
        {
            this.CorSecundaria = corSecundaria;
        }

        private void SetarCodigoExterno(Guid codigoExterno)
        {
            this.CodigoExterno = codigoExterno;
        }

        private void SetarTipoOrganizacao(TipoOrganizacaoEnum tipoOrganizacao)
        {
            this.TipoOrganizacao = tipoOrganizacao;
        }

        public async Task<ValidationResult> ValidaObjeto(OrganizacaoOrganizacao objeto)
        {
            OrganizacaoValidacao validacao = new OrganizacaoValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
