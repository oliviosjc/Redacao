using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Enums.Redacao
{
    public enum StatusRedacaoEnum
    {
        CRIADA = 1,
        AGUARDANDO_PROFESSOR = 2,
        COM_O_PROFESSOR = 3,
        EM_CORRECAO_PROFESSOR = 4,
        CORRIGIDA = 5
    }
}
