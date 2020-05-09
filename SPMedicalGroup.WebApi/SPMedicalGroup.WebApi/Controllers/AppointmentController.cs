using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMedicalGroup.WebApi.Domains;
using SPMedicalGroup.WebApi.Interfaces;
using SPMedicalGroup.WebApi.Repositories;

namespace SPMedicalGroup.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        
        public AppointmentController()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public IActionResult ListAll()
        {
            try
            {
                var itemsList = _appointmentRepository.ListAll();
                return Ok(itemsList);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult SearchById(int id)
        {
            try
            {
                var itemBuscado = _appointmentRepository.SearchById(id);
                return Ok(itemBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult SignUp(Consulta novaConsulta)
        {
            try
            {
                _appointmentRepository.SignUp(novaConsulta);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Confirm(Consulta newAppointment)
        {
            try
            {
                _appointmentRepository.Approve(newAppointment);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Cancel(Consulta newAppointment)
        {
            try
            {
                _appointmentRepository.Cancel(newAppointment);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Update(Consulta updatedAppointment)
        {
            try
            {
                _appointmentRepository.Update(updatedAppointment);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Delete(Consulta selectedAppointment)
        {
            try
            {
                _appointmentRepository.Delete(selectedAppointment);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}