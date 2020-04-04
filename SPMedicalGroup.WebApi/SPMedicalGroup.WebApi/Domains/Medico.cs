using System;
using System.Collections.Generic;

namespace SPMedicalGroup.WebApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }
        public string Crm { get; set; }
        public int? IdTelefone { get; set; }
        public int? IdEndereco { get; set; }
        public int IdClinica { get; set; }
        public int IdArea { get; set; }
        public int IdUsuario { get; set; }

        public Area IdAreaNavigation { get; set; }
        public Clinica IdClinicaNavigation { get; set; }
        public Endereco IdEnderecoNavigation { get; set; }
        public Telefone IdTelefoneNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
