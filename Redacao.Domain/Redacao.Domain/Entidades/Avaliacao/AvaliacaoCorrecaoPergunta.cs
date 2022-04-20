using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Enums.Avaliacao;
using Redacao.Domain.Enums.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Avaliacao
{
    public class AvaliacaoCorrecaoPergunta : EntidadeBase
    {
        public AvaliacaoCorrecaoPergunta()
        {

        }
        public TipoRedacaoEnum TipoRedacao { get; private set; }

        public string Titulo { get; private set; }

        public bool EObrigatoria { get; private set; }

        public AvaliacaoTipoPerguntaEnum TipoPergunta { get; private set; }

        public virtual ICollection<AvaliacaoCorrecaoPerguntaResposta> AvaliacaoCorrecaoPerguntaRespostas { get; private set; }
    }
}
