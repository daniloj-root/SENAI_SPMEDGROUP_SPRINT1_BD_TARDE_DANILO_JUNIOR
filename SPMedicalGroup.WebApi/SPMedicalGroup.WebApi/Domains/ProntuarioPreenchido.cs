using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Domains
{
    public class ProntuarioPreenchido
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
