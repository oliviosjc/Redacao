using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Validacoes.Documento;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Documento
{
    public class DocumentoDocumento : EntidadeBase
    {
        public DocumentoDocumento()
        {

        }

        public DocumentoDocumento(string nomeOriginal, string nomeInternoAzure ,
                                  string extensao, string tamanho, 
                                  Int32? temaId, Int32? redacaoId, Int32 id, 
                                  Int32 usuarioCriadorId, DateTime criadoEm,
                                  DateTime? modificadoEm, bool ativo)
        {
            this.SetarNomeOriginal(nomeOriginal);
            this.SetarNomeInternoAzure(nomeInternoAzure);
            this.SetarExtensao(extensao);
            this.SetarTamanho(tamanho);
            this.SetarTemaId(temaId);
            this.SetarRedacaoId(redacaoId);
            this.SetarId(id);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarAtivo(ativo);
        }

        public string NomeOriginal { get; private set; }

        public string NomeInternoAzure { get; private set; }

        public string Extensao { get; private set; }

        public string Tamanho { get; private set; }

        public Int32? RedacaoId { get; private set; }

        public Int32? TemaId { get; private set; }

        public virtual RedacaoRedacao Redacao { get; private set; }

        public virtual TemaRedacao Tema { get; private set; }

        public void SetarNomeOriginal(string nomeOriginal)
        {
            this.NomeOriginal = nomeOriginal;
        }

        public void SetarNomeInternoAzure(string nomeInternoAzure)
        {
            this.NomeInternoAzure = nomeInternoAzure;
        }

        public void SetarExtensao(string extensao)
        {
            this.Extensao = extensao;
        }

        public void SetarTamanho(string tamanho)
        {
            this.Tamanho = tamanho;
        }

        public void SetarTemaId(Int32? temaId)
        {
            this.TemaId = temaId;
        }

        public void SetarRedacaoId(Int32? redacaoId)
        {
            this.RedacaoId = redacaoId;
        }

        public async Task<ValidationResult> ValidaObjeto(DocumentoDocumento objeto)
        {
            DocumentoValidacao validacao = new DocumentoValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
