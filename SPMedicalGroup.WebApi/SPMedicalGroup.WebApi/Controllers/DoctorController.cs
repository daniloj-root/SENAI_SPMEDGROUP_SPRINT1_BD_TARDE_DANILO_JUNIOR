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
    public class DoctorController : ControllerBase
    {
        private DoctorRepository _doctorRepository { get; set; } 

        public DoctorController()
        {
            _doctorRepository = new DoctorRepository();
        }

        public IActionResult ListAll()
        {
            try
            {
                var itemsList = _doctorRepository.ListAll();
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
                var searchedItem = _doctorRepository.SearchById(id);
                return Ok(searchedItem);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult SignUp(Medico updatedDoctor)
        {
            try
            {
                _doctorRepository.SignUp(updatedDoctor);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Update(Medico updatedDoctor)
        {
            try
            {
                _doctorRepository.Update(updatedDoctor);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Delete(Medico selectedDoctor)
        {
            try
            {
                _doctorRepository.Delete(selectedDoctor);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}