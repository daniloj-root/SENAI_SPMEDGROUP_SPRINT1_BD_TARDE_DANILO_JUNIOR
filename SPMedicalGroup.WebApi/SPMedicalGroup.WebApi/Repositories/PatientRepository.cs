using SPMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Repositories
{
    public class PatientRepository : AnonRepository<Prontuario>
    {
        public new IEnumerable<ProntuarioPreenchido> ListAll()
        {
            return from p in Dbo.Prontuario
                join u in Dbo.Usuario on p.IdUsuario equals u.IdUsuario
                join e in Dbo.Endereco on p.IdEndereco equals e.IdEndereco
                join t in Dbo.Telefone on p.IdTelefone equals t.IdTelefone
                select new ProntuarioPreenchido
                {
                    Id = p.IdProntuario,
                    Nome = u.NomeUsuario,
                    Email = u.Email,
                    Rg = p.Rg,
                    Cpf = p.Cpf,
                    Endereco = e.Descricao,
                    Telefone = t.Descricao,
                    Nascimento = p.Nascimento
                };
        }
    }
}