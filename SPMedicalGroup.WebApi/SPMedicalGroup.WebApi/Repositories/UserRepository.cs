using Microsoft.EntityFrameworkCore;
using SPMedicalGroup.WebApi.Domains;
using SPMedicalGroup.WebApi.Interfaces;
using SPMedicalGroup.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPMedicalGroup.WebApi.Enums;
using IUser = SPMedicalGroup.WebApi.Interfaces.IUser;

namespace SPMedicalGroup.WebApi.Repositories
{
    public class UserRepository : AnonRepository<Usuario>, IUserRepository
    {
        private readonly DoctorRepository _doctorRepository;
        private readonly PatientRepository _patientRepository;
        
        public UserRepository()
        {
            _doctorRepository = new DoctorRepository();
            _patientRepository = new PatientRepository();
        }
        
        public bool CheckIfExistsByEmailAndPassword(string email, string password)
        {
            var searchedUser = Dbo.Usuario.First(x => x.Email.Equals(email) && x.Senha.Equals(password));
            return searchedUser != null;
        }

        public new IEnumerable<IUser> ListAll()
        {
            // Returns a list of doctors
            IEnumerable<IUser> listDoctors = _doctorRepository.ListAll();
            IEnumerable<IUser> listPatients = _patientRepository.ListAll();
            // Aggregates the list of doctors to a list of patients and returns the output
            return listPatients
                .Aggregate(listDoctors, (current, patient) => current
                    .Append(patient));
        }
        
        public IEnumerable<Usuario> ListAllNamesAndEmails()
        {
            return from u in Dbo.Usuario
                select new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email
                };
        }

        public new Usuario SearchById(int id)
        {
            return Dbo.Usuario.First(x => x.IdUsuario == id);
        }
    }
}