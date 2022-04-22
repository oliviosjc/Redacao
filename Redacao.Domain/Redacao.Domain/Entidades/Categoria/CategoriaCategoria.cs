using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Enums.Categoria;
using Redacao.Domain.Validacoes.Categoria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Categoria
{
    public class CategoriaCategoria : EntidadeBase
    {
        public CategoriaCategoria()
        {

        }

        public CategoriaCategoria(string nome, TipoCategoriaEnum tipoCategoria ,Int32 id, Int32 usuarioCriadorId, DateTime criadoEm, DateTime? modificadoEm, bool ativo)
        {
            this.SetarNome(nome);
            this.SetarTipoCategoria(tipoCategoria);
            this.SetarId(id);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarAtivo(ativo);
        }

        public string Nome { get; private set; }

        public TipoCategoriaEnum TipoCategoria { get; private set; }

        public virtual ICollection<TemaRedacao> TemasRedacoes { get; private set; }

        private void SetarNome(string nome)
        {
            this.Nome = nome;
        }

        private void SetarTipoCategoria(TipoCategoriaEnum tipoCategoria)
        {

        }

        public async Task<ValidationResult> ValidaObjeto(CategoriaCategoria objeto)
        {
            CategoriaValidacao validacao = new CategoriaValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
