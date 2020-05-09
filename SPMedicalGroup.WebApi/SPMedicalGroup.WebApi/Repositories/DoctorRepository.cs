using Microsoft.EntityFrameworkCore;
using SPMedicalGroup.WebApi.Domains;
using SPMedicalGroup.WebApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Repositories
{
    public class DoctorRepository : AnonRepository<Medico>
    {
        public new IEnumerable<MedicoPreenchido> ListAll()
        {
            return from m in Dbo.Medico
                join u in Dbo.Usuario on m.IdUsuario equals u.IdUsuario
                join c in Dbo.Clinica on m.IdClinica equals c.IdClinica
                join e in Dbo.Endereco on m.IdEndereco equals e.IdEndereco
                join t in Dbo.Telefone on m.IdTelefone equals t.IdTelefone
                select new MedicoPreenchido
                {
                    Id = m.IdMedico,
                    Nome = u.NomeUsuario,
                    Crm = m.Crm,
                    Email = u.Email,
                    Clinica = c.NomeFantasia,
                    Endereco = e.Descricao,
                    Telefone = t.Descricao
                };
        }
        
        public new IEnumerable<MedicoPreenchido> SearchById(int idInput)
        {
            return from m in Dbo.Medico
                join u in Dbo.Usuario on m.IdUsuario equals u.IdUsuario
                join c in Dbo.Clinica on m.IdClinica equals c.IdClinica
                join e in Dbo.Endereco on m.IdEndereco equals e.IdEndereco
                join t in Dbo.Telefone on m.IdTelefone equals t.IdTelefone
                where m.IdMedico == idInput
                select new MedicoPreenchido
                {
                    Id = m.IdMedico,
                    Nome = u.NomeUsuario,
                    Crm = m.Crm,
                    Email = u.Email,
                    Clinica = c.NomeFantasia,
                    Endereco = e.Descricao,
                    Telefone = t.Descricao
                };
        }
    }
}