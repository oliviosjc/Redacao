using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Categoria;
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

        public TemaRedacao(string nome, string descricao, Int32 categoriaId,
                           Int32 quantidadeLikes, Int32 quantidadeDeslikes, Int32 id, 
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
            this.SetarCategoria(categoriaId);
            this.SetarQuantidadeDeslikes(quantidadeDeslikes);
            this.SetarQuantidadeLikes(quantidadeLikes);
        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public Int32 CategoriaId { get; private set; }

        public Int32 QuantidadeLikes { get; private set; }

        public Int32 QuantidadeDeslikes { get; private set; }

        public virtual CategoriaCategoria Categoria { get; private set; } 

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

        private void SetarCategoria(Int32 categoriaId)
        {
            this.CategoriaId = categoriaId;
        }

        public void SetarQuantidadeLikes(Int32 quantidadeLikes)
        {
            this.QuantidadeLikes = quantidadeLikes;
        }

        public void SetarQuantidadeDeslikes(Int32 quantidadeDeslikes)
        {
            this.QuantidadeDeslikes = quantidadeDeslikes;
        }
    }
}
