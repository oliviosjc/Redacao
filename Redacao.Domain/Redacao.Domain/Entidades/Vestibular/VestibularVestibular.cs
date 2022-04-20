using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Validacoes.Vestibular;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Vestibular
{
    public class VestibularVestibular : EntidadeBase
    {
        public VestibularVestibular()
        {

        }

        public VestibularVestibular(string nome, string descricao,
                                    Int32 id, Int32 usuarioCriadorId, 
                                    DateTime criadoEm, DateTime? modificadoEm,
                                    bool ativo)
        {
            this.SetarNome(nome);
            this.SetarDescricao(descricao);
            this.SetarId(id);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarAtivo(ativo);
        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public virtual ICollection<VestibularTema> Temas { get; private set; }

        private void SetarNome(string nome)
        {
            this.Nome = nome;
        }

        private void SetarDescricao(string descricao)
        {
            this.Descricao = descricao;
        }

        public async Task<ValidationResult> ValidaObjeto(VestibularVestibular objeto)
        {
            VestibularValidacao validacao = new VestibularValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
