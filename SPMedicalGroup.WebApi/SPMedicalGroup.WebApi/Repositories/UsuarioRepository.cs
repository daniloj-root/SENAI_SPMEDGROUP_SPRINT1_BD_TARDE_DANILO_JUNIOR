using Microsoft.EntityFrameworkCore;
using SPMedicalGroup.WebApi.Domains;
using SPMedicalGroup.WebApi.Interfaces;
using SPMedicalGroup.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Repositories
{
    public class UsuarioRepository : GeneralRepository<Usuario>, IUsuarioRepository
    {
        public bool VerificarPorEmailSenha(string email, string senha)
        {
            var usuarioBuscado = dbo.Usuario.First(x => x.Email.Equals(email) && x.Senha.Equals(senha));

            if (usuarioBuscado == null)
            {
                return false;
            }

            return true;
        }

        new public IEnumerable<UsuarioGenerico> Listar()
        {
           IGeneralRepository<Medico> _medicoRepository = new MedicoRepository();
           IGeneralRepository<Prontuario> _prontuarioRepository = new ProntuarioRepository();
           //TODO: Listar todos os usuários com JOIN
        }

        public IEnumerable<Usuario> ListarApenasEmailSenhaTipo()
        {
            return dbo.Usuario;
        }

        new public Usuario BuscarPorId(int id)
        {
            return dbo.Usuario
                        .First(x => x.IdUsuario == id);
        }
    }
}
