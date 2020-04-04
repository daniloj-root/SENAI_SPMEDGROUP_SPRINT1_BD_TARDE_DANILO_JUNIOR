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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;
        
        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        public IActionResult Listar()
        {
            try
            {
                var listaItens = _consultaRepository.Listar();
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
                var itemBuscado = _consultaRepository.BuscarPorId(id);
                return Ok(itemBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Cadastrar(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Confirmar(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Confirmar(novaConsulta);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Cancelar(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cancelar(novaConsulta);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Atualizar(Consulta consultaAtualizado)
        {
            try
            {
                _consultaRepository.Atualizar(consultaAtualizado);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Deletar(Consulta consultaSelecionada)
        {
            try
            {
                _consultaRepository.Deletar(consultaSelecionada);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}