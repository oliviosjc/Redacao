using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Enums.Suporte.Sugestao;
using Redacao.Domain.Validacoes.Suporte.Sugestao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Suporte.Sugestao
{
    public class SugestaoSugestao : EntidadeBase
    {
        public SugestaoSugestao()
        {

        }

        public SugestaoSugestao(TipoSugestaoEnum tipo, StatusSugestaoEnum status, string descricao,
                                string resposta,
                                Int32 id, Int32 usuarioCriadorId, DateTime criadoEm, DateTime? modificadoEm,
                                bool ativo)
        {
            this.SetarId(id);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarAtivo(ativo);
            this.SetarTipo(tipo);
            this.SetarStatus(status);
            this.SetarDescricao(Descricao);
            this.SetarResposta(resposta);
        }

        public TipoSugestaoEnum Tipo { get; private set; } 

        public StatusSugestaoEnum Status { get; private set; }

        public string Descricao { get; private set; }

        public string Resposta { get; private set; }

        private void SetarTipo(TipoSugestaoEnum tipo)
        {
            this.Tipo = tipo;
        }

        private void SetarStatus(StatusSugestaoEnum status)
        {
            this.Status = status;
        }

        private void SetarDescricao(string descricao)
        {
            this.Descricao = descricao;
        }

        public void SetarResposta(string resposta)
        {
            this.Resposta = resposta;
        }

        public async Task<ValidationResult> ValidaObjeto(SugestaoSugestao objeto)
        {
            SugestaoValidacao validacao = new SugestaoValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
