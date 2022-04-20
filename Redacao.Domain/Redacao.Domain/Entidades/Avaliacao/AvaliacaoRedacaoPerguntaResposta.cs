using Redacao.Domain.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Avaliacao
{
    public class AvaliacaoRedacaoPerguntaResposta : EntidadeBase
    {
        public AvaliacaoRedacaoPerguntaResposta()
        {

        }

        public string Valor { get; private set; }

        public Int32? AvaliacaoRedacaoPerguntaId { get; private set; }

        public virtual AvaliacaoRedacaoPergunta AvaliacaoRedacaoPergunta { get; private set; }

        public virtual ICollection<AvaliacaoRedacaoRespostaAluno> AvaliacaoRedacaoRespostaAlunos { get; private set; }
    }
}
