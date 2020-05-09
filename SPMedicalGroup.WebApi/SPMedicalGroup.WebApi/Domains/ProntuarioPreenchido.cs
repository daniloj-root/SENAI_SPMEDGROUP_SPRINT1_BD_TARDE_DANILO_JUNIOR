using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPMedicalGroup.WebApi.Interfaces;

namespace SPMedicalGroup.WebApi.Domains
{
    public class ProntuarioPreenchido : IUser
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
