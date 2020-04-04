using System;
using System.Collections.Generic;

namespace SPMedicalGroup.WebApi.Domains
{
    public partial class Telefone
    {
        public Telefone()
        {
            Medico = new HashSet<Medico>();
            Prontuario = new HashSet<Prontuario>();
        }

        public int IdTelefone { get; set; }
        public string Descricao { get; set; }

        public ICollection<Medico> Medico { get; set; }
        public ICollection<Prontuario> Prontuario { get; set; }
    }
}
