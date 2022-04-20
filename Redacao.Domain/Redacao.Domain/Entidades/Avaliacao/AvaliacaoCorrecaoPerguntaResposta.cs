using Redacao.Domain.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Avaliacao
{
    public class AvaliacaoCorrecaoPerguntaResposta : EntidadeBase
    {
        public AvaliacaoCorrecaoPerguntaResposta()
        {

        }

        public string Valor { get; private set; }

        public Int32? AvaliacaoCorrecaoPerguntaId { get; private set; }

        public virtual AvaliacaoCorrecaoPergunta AvaliacaoCorrecaoPergunta { get; private set; }

        public virtual ICollection<AvaliacaoCorrecaoRespostaProfessor> AvaliacaoCorrecaoRespostaProfessores { get; private set; }
    }
}
