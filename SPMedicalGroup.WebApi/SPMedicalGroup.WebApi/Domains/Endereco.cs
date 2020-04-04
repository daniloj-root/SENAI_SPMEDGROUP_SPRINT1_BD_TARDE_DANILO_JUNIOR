using System;
using System.Collections.Generic;

namespace SPMedicalGroup.WebApi.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clinica = new HashSet<Clinica>();
            Medico = new HashSet<Medico>();
            Prontuario = new HashSet<Prontuario>();
        }

        public int IdEndereco { get; set; }
        public string Descricao { get; set; }

        public ICollection<Clinica> Clinica { get; set; }
        public ICollection<Medico> Medico { get; set; }
        public ICollection<Prontuario> Prontuario { get; set; }
    }
}
