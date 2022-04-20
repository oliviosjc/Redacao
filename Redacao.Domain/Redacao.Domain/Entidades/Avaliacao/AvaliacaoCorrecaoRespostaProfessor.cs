using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Avaliacao
{
    public class AvaliacaoCorrecaoRespostaProfessor : EntidadeBase
    {
        public AvaliacaoCorrecaoRespostaProfessor()
        {

        }

        public Int32 RedacaoId { get; private set; }

        public string Resposta { get; private set; }

        public Int32? AvaliacaoCorrecaoPerguntaRespostaId { get; private set; }

        public virtual AvaliacaoCorrecaoPerguntaResposta AvaliacaoCorrecaoPerguntaResposta { get; private set; }

        public virtual RedacaoRedacao Redacao { get; private set; }
    }
}
