using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Vestibular
{
    public class VestibularVestibular : EntidadeBase
    {
        public VestibularVestibular()
        {

        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public Int32 OrganizacaoId { get; private set; }

        public virtual OrganizacaoOrganizacao Organizacao { get; private set; }

        public virtual ICollection<TemaRedacao> TemasRedacao { get; private set; }
    }
}
