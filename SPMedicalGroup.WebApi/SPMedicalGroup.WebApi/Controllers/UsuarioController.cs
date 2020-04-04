using Microsoft.AspNetCore.Mvc;
using SPMedicalGroup.WebApi.Domains;
using SPMedicalGroup.WebApi.Interfaces;
using SPMedicalGroup.WebApi.Models;
using SPMedicalGroup.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.WebApi.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public IActionResult Login(LoginViewModel usuarioLogando)
        {
            if (!(_usuarioRepository.VerificarPorEmailSenha(usuarioLogando.Email, usuarioLogando.Senha)))
                return NotFound();

            //TODO: Criar token JWT
            return Ok();
        }

        public IActionResult Listar()
        {
            try
            {
                var listaItens = _usuarioRepository.Listar();
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
                var itemBuscado = _usuarioRepository.BuscarPorId(id);
                return Ok(itemBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Atualizar(Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.Atualizar(usuarioAtualizado);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Deletar(Usuario usuarioSelecionada)
        {
            try
            {
                _usuarioRepository.Deletar(usuarioSelecionada);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
