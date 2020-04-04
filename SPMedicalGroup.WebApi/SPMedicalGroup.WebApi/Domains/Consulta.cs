using System;
using System.Collections.Generic;

namespace SPMedicalGroup.WebApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }
        public int IdClinica { get; set; }
        public int IdMedico { get; set; }
        public int IdProntuario { get; set; }
        public int? IdSituacao { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
        public Medico IdMedicoNavigation { get; set; }
        public Prontuario IdProntuarioNavigation { get; set; }
        public Situacao IdSituacaoNavigation { get; set; }
    }
}
