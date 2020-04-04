using SPMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Interfaces
{
    interface IUsuarioRepository : IGeneralRepository<Usuario>
    {
        bool VerificarPorEmailSenha(string email, string senha);
    }
}
