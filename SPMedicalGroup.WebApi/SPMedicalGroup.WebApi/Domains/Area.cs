using System;
using System.Collections.Generic;

namespace SPMedicalGroup.WebApi.Domains
{
    public partial class Area
    {
        public Area()
        {
            Medico = new HashSet<Medico>();
        }

        public int IdArea { get; set; }
        public string Descricao { get; set; }

        public ICollection<Medico> Medico { get; set; }
    }
}
