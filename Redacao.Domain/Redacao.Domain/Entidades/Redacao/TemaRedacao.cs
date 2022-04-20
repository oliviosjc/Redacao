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

        public TemaRedacao(string nome, string descricao, Int32 id, 
                           Int32 usuarioCriadorId, DateTime criadoEm,
                           DateTime? modificadoEm, bool ativo)
        {
            this.SetarNome(nome);
            this.SetarDescricao(descricao);
            this.SetarId(id);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarAtivo(ativo);
        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }


        public virtual ICollection<RedacaoRedacao> Redacoes { get; private set; }

        public virtual ICollection<DocumentoDocumento> DocumentosTema { get; private set; }

        public virtual ICollection<VestibularTema> Vestibulares { get; private set; }

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
    }
}
