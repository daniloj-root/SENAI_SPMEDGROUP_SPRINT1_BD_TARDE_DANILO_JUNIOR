using SPMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Repositories
{
    public class ProntuarioRepository : GeneralRepository<Prontuario>
    {
        new public IEnumerable<ProntuarioPreenchido> Listar()
        {
            return from prontuarios in dbo.Prontuario
                   join usuarios in dbo.Usuario on prontuarios.IdUsuario equals usuarios.IdUsuario
                   join enderecos in dbo.Endereco on prontuarios.IdEndereco equals enderecos.IdEndereco
                   join telefones in dbo.Telefone on prontuarios.IdTelefone equals telefones.IdTelefone
                   select new ProntuarioPreenchido
                   {
                       ID = prontuarios.IdProntuario,
                       Nome = usuarios.NomeUsuario,
                       Email = usuarios.Email,
                       RG = prontuarios.Rg,
                       CPF = prontuarios.Cpf,
                       Endereco = enderecos.Descricao,
                       Telefone = telefones.Descricao,
                       Nascimento = prontuarios.Nascimento
                   };
        }
    }
}
