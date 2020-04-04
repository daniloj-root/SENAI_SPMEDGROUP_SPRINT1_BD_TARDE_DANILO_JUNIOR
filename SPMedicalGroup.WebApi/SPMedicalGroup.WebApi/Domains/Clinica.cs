using System;
using System.Collections.Generic;

namespace SPMedicalGroup.WebApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Consulta = new HashSet<Consulta>();
            Medico = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string IdTelefone { get; set; }
        public int? IdEndereco { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }

        public Endereco IdEnderecoNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
        public ICollection<Medico> Medico { get; set; }
    }
}
