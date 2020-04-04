using SPMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Interfaces
{
    interface IConsultaRepository : IGeneralRepository<Consulta>
    {
        IEnumerable<Consulta> ListarPorPaciente(int idPaciente);
        IEnumerable<Consulta> ListarPorMedico(int idMedico);
        void Confirmar(Consulta consultaAConfirmar);
        void Cancelar(Consulta consultaAConfirmar);
    }
}
