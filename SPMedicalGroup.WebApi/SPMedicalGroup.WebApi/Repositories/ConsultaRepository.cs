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
    public class ConsultaRepository : GeneralRepository<Consulta>, IConsultaRepository
    {
        public IEnumerable<Consulta> ListarPorPaciente(int idPaciente)
        {
            return from consultas in dbo.Consulta
                   join prontuarios in dbo.Prontuario on consultas.IdProntuario equals prontuarios.IdProntuario
                   where prontuarios.IdUsuario == idPaciente
                   select consultas;
        }

        public IEnumerable<Consulta> ListarPorMedico(int idMedico)
        {
            return dbo.Consulta.Where(x => x.IdMedico == idMedico);
        }

        public void Confirmar(Consulta consultaRequest)
        {
            consultaRequest.IdSituacao = (int)StatusConsulta.CONFIRMADA;

            dbo.Consulta.Update(consultaRequest);
            dbo.SaveChanges();
        }

        public void Cancelar(Consulta consultaACancelar)
        {
            consultaACancelar.IdSituacao = (int)StatusConsulta.CANCELADA;
            var consultaCancelada = consultaACancelar;

            dbo.Consulta.Update(consultaCancelada);
            dbo.SaveChanges();
        }
    }
}
