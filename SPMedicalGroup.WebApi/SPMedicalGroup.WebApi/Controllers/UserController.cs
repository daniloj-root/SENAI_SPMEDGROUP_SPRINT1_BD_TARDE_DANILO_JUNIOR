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
    public class UserController : ControllerBase
    {
        private IUserRepository UserRepository { get; }

        public UserController()
        {
            UserRepository = new UserRepository();
        }

        public IActionResult Login(LoginViewModel loggingUser)
        {
            if (!(UserRepository.CheckIfExistsByEmailAndPassword(loggingUser.Email, loggingUser.Senha)))
                return NotFound();

            //TODO: Create JWT Token
            return Ok();
        }

        public IActionResult ListAll()
        {
            try
            {
                var itemsList = UserRepository.ListAll();
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
                var searchItem = UserRepository.SearchById(id);
                return Ok(searchItem);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult SignUp(Usuario newUser)
        {
            try
            {
                UserRepository.SignUp(newUser);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Update(Usuario updatedUser)
        {
            try
            {
                UserRepository.Update(updatedUser);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public IActionResult Delete(Usuario selectedUser)
        {
            try
            {
                UserRepository.Delete(selectedUser);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
