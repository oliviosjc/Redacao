using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Validacoes.Vestibular;
using System;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Vestibular
{
    public class VestibularTema : EntidadeBase
    {
        public VestibularTema()
        {

        }

        public VestibularTema(Int32 temaId, Int32 vestibularId, Int32 id, 
                              Int32 usuarioCriadorId, DateTime criadoEm,
                              DateTime? modificadoEm, bool ativo)
        {
            this.SetarTemaId(temaId);
            this.SetarVestibularId(vestibularId);
            this.SetarId(id);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarAtivo(ativo);
        }

        public Int32 TemaId { get; private set; }

        public Int32 VestibularId { get; private set; }

        public virtual TemaRedacao Tema { get; private set; }

        public virtual VestibularVestibular Vestibular { get; private set; }

        private void SetarTemaId(Int32 temaId)
        {
            this.TemaId = temaId;
        }

        private void SetarVestibularId(Int32 vestibularId)
        {
            this.VestibularId = vestibularId;
        }

        public async Task<ValidationResult> ValidaObjeto(VestibularTema objeto)
        {
            VestibularTemaValidacao validacao = new VestibularTemaValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
