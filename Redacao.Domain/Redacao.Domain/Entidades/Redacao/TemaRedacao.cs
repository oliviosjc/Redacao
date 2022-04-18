using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Documento;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Vestibular;
using Redacao.Domain.Validacoes.Redacao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Redacao
{
    public class TemaRedacao : EntidadeBase
    {
        public TemaRedacao()
        {

        }

        public TemaRedacao(Int32 id, string nome, string descricao, Int32 organizacaoId, Int32 vestibularId, AcaoEntidadeEnum acaoEntidade, Int32 usuarioId)
        {
            this.SetarNome(nome);
            this.SetarDescricao(descricao);
            this.SetarOrganizacaoId(organizacaoId);
            this.SetarVestibularId(vestibularId);
        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public Int32 OrganizacaoId { get; private set; }

        public Int32 VestibularId { get; private set; }

        public virtual OrganizacaoOrganizacao Organizacao { get; private set; }

        public virtual VestibularVestibular Vestibular { get; private set; }

        public virtual ICollection<RedacaoRedacao> Redacoes { get; private set; }

        public virtual ICollection<DocumentoDocumento> DocumentosTema { get; private set; }

        public async Task<ValidationResult> ValidaObjeto(TemaRedacao objeto)
        {
            TemaRedacaoValidacao validacao = new TemaRedacaoValidacao();
            return await validacao.ValidateAsync(objeto);
        }

        private void SetarNome(string nome)
        {
            this.Nome = nome;
        }

        private void SetarDescricao(string descricao)
        {
            this.Descricao = descricao;
        }

        private void SetarOrganizacaoId(Int32 organizacaoId)
        {
            this.OrganizacaoId = organizacaoId;
        }

        private void SetarVestibularId(Int32 vestibularId)
        {
            this.VestibularId = vestibularId;
        }
    }
}
