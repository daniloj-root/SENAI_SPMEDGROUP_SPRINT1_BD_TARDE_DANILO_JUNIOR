using SPMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Interfaces
{
    internal interface IAppointmentRepository : IAnonRepository<Consulta>
    {
        IEnumerable<Consulta> ListByPatientsId(int id);
        IEnumerable<Consulta> ListByDoctorsId(int id);
        void Approve(Consulta pendingAppointment);
        void Cancel(Consulta pendingAppointment);
    }
}
