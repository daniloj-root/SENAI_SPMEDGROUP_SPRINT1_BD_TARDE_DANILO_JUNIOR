using SPMedicalGroup.WebApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Models
{
    public class RepositoryBase
    {
        protected SpMedGroupContext Dbo;

        public RepositoryBase()
        {
            Dbo = new SpMedGroupContext();
        }
    }
}
