using Microsoft.EntityFrameworkCore;
using SPMedicalGroup.WebApi.Domains;
using SPMedicalGroup.WebApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Repositories
{
    public class MedicoRepository : GeneralRepository<Medico>
    {
        new public IEnumerable<MedicoPreenchido> Listar()
        {
            return from medico in dbo.Medico
                   join usuario in dbo.Usuario on medico.IdUsuario equals usuario.IdUsuario
                   join clinica in dbo.Clinica on medico.IdClinica equals clinica.IdClinica
                   join endereco in dbo.Endereco on medico.IdEndereco equals endereco.IdEndereco
                   join telefone in dbo.Telefone on medico.IdTelefone equals telefone.IdTelefone
                   select new MedicoPreenchido
                   {
                       ID = medico.IdMedico,
                       Nome = usuario.NomeUsuario,
                       CRM = medico.Crm,
                       Email = usuario.Email,
                       Clinica = clinica.NomeFantasia,
                       Endereco = endereco.Descricao,
                       Telefone = telefone.Descricao
                   };
        }
        new public IEnumerable<MedicoPreenchido> BuscarPorId(int idInput)
        {
            return from medico in dbo.Medico
                   join usuario in dbo.Usuario on medico.IdUsuario equals usuario.IdUsuario
                   join clinica in dbo.Clinica on medico.IdClinica equals clinica.IdClinica
                   join endereco in dbo.Endereco on medico.IdEndereco equals endereco.IdEndereco
                   join telefone in dbo.Telefone on medico.IdTelefone equals telefone.IdTelefone
                   where medico.IdMedico == idInput
                   select new MedicoPreenchido
                   {
                       ID = medico.IdMedico,
                       Nome = usuario.NomeUsuario,
                       CRM = medico.Crm,
                       Email = usuario.Email,
                       Clinica = clinica.NomeFantasia,
                       Endereco = endereco.Descricao,
                       Telefone = telefone.Descricao
                   };
        }
    }
}
