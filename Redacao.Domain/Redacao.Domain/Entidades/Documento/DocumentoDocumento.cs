using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Enums.Documento;
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

        public DocumentoDocumento(string nomeOriginal, string nomeInternoAzure,
                                  string extensao, string tamanho, TipoDocumentoEnum tipo,
                                  Int32 chaveValor, Int32 id, 
                                  Int32 usuarioCriadorId, DateTime criadoEm,
                                  DateTime? modificadoEm, bool ativo)
        {
            this.SetarNomeOriginal(nomeOriginal);
            this.SetarNomeInternoAzure(nomeInternoAzure);
            this.SetarExtensao(extensao);
            this.SetarTamanho(tamanho);
            this.SetarId(id);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarAtivo(ativo);
            this.SetarChaveValor(chaveValor);
            this.SetarTipoDocumento(tipo);
        }

        public string NomeOriginal { get; private set; }

        public string NomeInternoAzure { get; private set; }

        public string Extensao { get; private set; }

        public string Tamanho { get; private set; }

        public Int32 ChaveValor { get; private set; }

        public TipoDocumentoEnum Tipo { get; private set; }

        private void SetarNomeOriginal(string nomeOriginal)
        {
            this.NomeOriginal = nomeOriginal;
        }

        private void SetarNomeInternoAzure(string nomeInternoAzure)
        {
            this.NomeInternoAzure = nomeInternoAzure;
        }

        private void SetarExtensao(string extensao)
        {
            this.Extensao = extensao;
        }

        private void SetarTamanho(string tamanho)
        {
            this.Tamanho = tamanho;
        }

        private void SetarChaveValor(Int32 chaveValor)
        {
            this.ChaveValor = chaveValor;
        }

        private void SetarTipoDocumento(TipoDocumentoEnum tipo)
        {
            this.Tipo = tipo;
        }

        public async Task<ValidationResult> ValidaObjeto(DocumentoDocumento objeto)
        {
            DocumentoValidacao validacao = new DocumentoValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
