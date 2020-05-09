using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Interfaces
{
    internal interface IAnonRepository<T>
    {
        IEnumerable<T> ListAll();
        T SearchById(int id);
        void SignUp(T newItem);
        void Update(T updatedItem);
        void Delete(T selectedItem);
    }
}
