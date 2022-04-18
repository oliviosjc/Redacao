using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Redacao.Domain.Entidades.Base
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; private set; }

        public DateTime CriadoEm { get; private set; }

        public DateTime? ModificadoEm { get; private set; }

        public bool Ativo { get; private set; }

        public Int32 UsuarioCriadorId { get; private set; }

        public virtual UsuarioUsuario UsuarioCriador { get; private set; }

        public void SetarId(Int32 id)
        {
            this.Id = id;
        }

        public void SetarUsuarioCriadorId(Int32 usuarioCriadorId)
        {
            this.UsuarioCriadorId = usuarioCriadorId;
        }

        public void SetarCriadoEm(DateTime criadoEm)
        {
            this.CriadoEm = criadoEm;
        }

        public void SetarModificadoEm(DateTime? modificadoEm)
        {
            this.ModificadoEm = modificadoEm;
        }

        public void SetarAtivo(bool flag)
        {
            this.Ativo = flag;
        }
    }
}
