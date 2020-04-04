using System;
using System.Collections.Generic;

namespace SPMedicalGroup.WebApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }
        public string Descricao { get; set; }

        public ICollection<Consulta> Consulta { get; set; }
    }
}
