using Microsoft.AspNetCore.Http;
using SPMedicalGroup.WebApi.Domains;
using SPMedicalGroup.WebApi.Enums;
using SPMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Repositories
{
    public class AppointmentRepository : AnonRepository<Consulta>, IAppointmentRepository
    {
        public IEnumerable<Consulta> ListByPatientsId(int id)
        {
            return from c in Dbo.Consulta
                join p in Dbo.Prontuario on c.IdProntuario equals p.IdProntuario
                where p.IdUsuario == id
                select c;
        }
        
        public IEnumerable<Consulta> ListByDoctorsId(int id)
        {
            return from c in Dbo.Consulta
                where c.IdMedico == id
                select c;
        }

        public void Approve(Consulta pendingAppointment)
        {
            pendingAppointment.IdSituacao = (int) AppointmentStatus.Confirmed;
            Dbo.Consulta.Update(pendingAppointment);
            Dbo.SaveChanges();
        }
        
        public void Cancel(Consulta pendingAppointment)
        {
            pendingAppointment.IdSituacao = (int) AppointmentStatus.Cancelled;
            var cancelledAppointment = pendingAppointment;

            Dbo.Consulta.Update(cancelledAppointment);
            Dbo.SaveChanges();
        }
    }
}