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
    public class MedicoController : ControllerBase
    {
        private IGeneralRepository<Medico> _medicoRepository { get; set; } 

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        public IActionResult Listar()
        {
            try
            {
                var listaItens = _medicoRepository.Listar();
                return Ok(listaItens);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var itemBuscado = _medicoRepository.BuscarPorId(id);
                return Ok(itemBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Cadastrar(Medico novoMedico)
        {
            try
            {
                _medicoRepository.Cadastrar(novoMedico);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Atualizar(Medico medicoAtualizado)
        {
            try
            {
                _medicoRepository.Atualizar(medicoAtualizado);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Deletar(Medico medicoSelecionada)
        {
            try
            {
                _medicoRepository.Deletar(medicoSelecionada);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}