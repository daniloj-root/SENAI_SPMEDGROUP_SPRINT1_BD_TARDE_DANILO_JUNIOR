using SPMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Interfaces
{
    internal interface IUserRepository : IAnonRepository<Usuario>
    {
        bool CheckIfExistsByEmailAndPassword(string email, string password);
    }
}
