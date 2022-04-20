using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Avaliacao
{
    public class AvaliacaoRedacaoRespostaAluno : EntidadeBase
    {
        public AvaliacaoRedacaoRespostaAluno()
        {

        }

        public Int32 RedacaoId { get; private set; }

        public string Resposta { get; private set; }

        public Int32? AvaliacaoRedacaoPerguntaRespostaId { get; private set; }

        public virtual AvaliacaoRedacaoPerguntaResposta AvaliacaoRedacaoPerguntaResposta { get; private set; }

        public virtual RedacaoRedacao Redacao { get; private set; }
    }
}
