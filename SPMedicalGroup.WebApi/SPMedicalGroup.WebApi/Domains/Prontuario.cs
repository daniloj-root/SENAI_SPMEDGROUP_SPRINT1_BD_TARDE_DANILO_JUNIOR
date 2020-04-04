using System;
using System.Collections.Generic;

namespace SPMedicalGroup.WebApi.Domains
{
    public partial class Prontuario
    {
        public Prontuario()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdProntuario { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime Nascimento { get; set; }
        public int? IdTelefone { get; set; }
        public int? IdEndereco { get; set; }
        public int IdUsuario { get; set; }

        public Endereco IdEnderecoNavigation { get; set; }
        public Telefone IdTelefoneNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
