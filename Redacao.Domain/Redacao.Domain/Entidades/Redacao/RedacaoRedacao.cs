using FluentValidation.Results;
using Redacao.Domain.Entidades.Avaliacao;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Documento;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Entidades.Vestibular;
using Redacao.Domain.Enums.Redacao;
using Redacao.Domain.Validacoes.Redacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Redacao
{
    public class RedacaoRedacao : EntidadeBase
    {
        public RedacaoRedacao()
        {

        }

        public RedacaoRedacao(string descricao, Int32 temaRedacaoId, Int32 vestibularId, 
                              Int32 usuarioAlunoId, Int32? professorResponsavelId, TipoRedacaoEnum tipoRedacaoEnum,
                              StatusRedacaoEnum statusRedacao, Int32 id, Int32 usuarioCriadorId, DateTime criadoEm,
                              DateTime? modificadoEm, bool ativo)
        {
            this.SetarDescricao(descricao);
            this.SetarTemaRedacaoId(temaRedacaoId);
            this.SetarVestibularId(vestibularId);
            this.SetarUsuarioAlunoId(usuarioAlunoId);
            this.SetarProfessorResponsavelId(professorResponsavelId);
            this.SetarTipoRedacao(tipoRedacaoEnum);
            this.SetarStatusRedacao(statusRedacao);
            this.SetarId(id);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarAtivo(ativo);
        }

        public string Descricao { get; private set; }

        public Int32 TemaRedacaoId { get; private set; }

        public Int32 VestibularId { get; private set; }

        public Int32 UsuarioAlunoId { get; private set; }

        public Int32? ProfessorResponsavelId { get; private set; }

        public virtual TipoRedacaoEnum TipoRedacao { get; private set; }

        public virtual StatusRedacaoEnum StatusRedacao { get; private set; }

        public virtual TemaRedacao TemaRedacao { get; private set; }

        public virtual VestibularVestibular Vestibular { get; private set; }

        public virtual UsuarioUsuario Usuario { get; private set; }

        public virtual ICollection<DocumentoDocumento> DocumentosRedacao { get; private set; }

        public virtual ICollection<AvaliacaoRedacaoRespostaAluno> AvaliacaoRedacaoRespostaAlunos { get; private set; }

        public virtual ICollection<AvaliacaoCorrecaoRespostaProfessor> AvaliacaoCorrecaoRespostaProfessores { get; private set; }

        private void SetarDescricao(string descricao)
        {
            this.Descricao = descricao;
        }

        private void SetarTemaRedacaoId(Int32 temaId)
        {
            this.TemaRedacaoId = temaId;
        }

        private void SetarVestibularId(Int32 vestibularId)
        {
            this.VestibularId = vestibularId;
        }

        private void SetarUsuarioAlunoId(Int32 usuarioAlunoId)
        {
            this.UsuarioAlunoId = usuarioAlunoId;
        }

        private void SetarProfessorResponsavelId(Int32? professorResponsavelId)
        {
            this.ProfessorResponsavelId = professorResponsavelId;
        }

        private void SetarTipoRedacao(TipoRedacaoEnum tipoRedacao)
        {
            this.TipoRedacao = tipoRedacao;
        }

        private void SetarStatusRedacao(StatusRedacaoEnum statusRedacao)
        {
            this.StatusRedacao = statusRedacao;
        }

        public async Task<ValidationResult> ValidaObjeto(RedacaoRedacao objeto)
        {
            RedacaoValidacao validacao = new RedacaoValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
