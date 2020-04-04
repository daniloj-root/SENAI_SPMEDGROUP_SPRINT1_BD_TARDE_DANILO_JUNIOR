using System;
using System.Collections.Generic;

namespace SPMedicalGroup.WebApi.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Descricao { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
