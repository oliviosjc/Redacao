using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Documento
{
    public class DocumentoDocumento : EntidadeBase
    {
        public DocumentoDocumento()
        {

        }

        public Guid AmazonS3Id { get; private set; }

        public string Nome { get; private set; }

        public string Extensao { get; private set; }

        public string Tamanho { get; private set; }

        public Int32 OrganizacaoId { get; private set; }

        public Int32? RedacaoId { get; private set; }

        public Int32? TemaId { get; private set; }

        public virtual OrganizacaoOrganizacao Organizacao { get; private set; }

        public virtual RedacaoRedacao Redacao { get; private set; }

        public virtual TemaRedacao Tema { get; private set; }
    }
}
