using SR39_2021_pop2022_2.Models;

using SR39_2021_pop2022_2.Repositories;
//using SR39_2021_pop2022_2.Repositories.SR39_2021_POP2022_2.Repositories;
using SR39_2021_POP2022_2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    class ProfessorService : IProfessorService
    {
        private IProfessorRepository professorRepository;
        private IUserRepository userRepository;

        public ProfessorService()
        {
            professorRepository = new ProfessorRepository();
            userRepository = new UserRepository();
        }

        public Professor GetById(int id)
        {
            return professorRepository.GetById(id);
        }

        public List<Professor> GetAll()
        {
            return professorRepository.GetAll();
        }

        public List<Professor> GetActiveProfessors()
        {
            return professorRepository.GetAll().Where(p => p.User.IsActive).ToList();
        }

        public List<Professor> GetActiveProfessorsByEmail(string email)
        {
            return professorRepository.GetAll().Where(p => p.User.IsActive && p.User.Email.Contains(email)).ToList();
        }
        public List<Professor> GetActiveProfessorsOrderedByEmail()
        {
            return professorRepository.GetAll().Where(p => p.User.IsActive).OrderBy(p => p.User.Email).ToList();
        }

        public void Add(Professor professor)
        {
            var userId = userRepository.Add(professor.User);
            professor.UserId = userId;
            professorRepository.Add(professor);
        }

        public void Update(int id, Professor professor)
        {
            userRepository.Update(professor.UserId, professor.User);
            professorRepository.Update(id, professor);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
            professorRepository.Delete(id);
        }

        public List<User> ListAllStudents()
        {
            throw new NotImplementedException();
        }
        //class ProfessorService : IProfessorService
        //{
        //    private IProfessorRepository professorRepository;
        //    private IUserRepository userRepository;

        //    public ProfessorService()
        //    {
        //        professorRepository = new ProfessorRepository();
        //        userRepository = new UserRepository();
        //    }

        //    public Professor GetById(int id)
        //    {
        //        return professorRepository.GetById(id);
        //    }

        //    public List<Professor> GetAll()
        //    {
        //        return professorRepository.GetAll();
        //    }

        //    public List<Professor> GetActiveProfessors()
        //    {
        //        return professorRepository.GetAll().Where(p => p.User.IsActive).ToList();
        //    }

        //    public List<Professor> GetActiveProfessorsByEmail(string email)
        //    {
        //        return professorRepository.GetAll().Where(p => p.User.IsActive && p.User.Email.Contains(email)).ToList();
        //    }
        //    public List<Professor> GetActiveProfessorsOrderedByEmail()
        //    {
        //        return professorRepository.GetAll().Where(p => p.User.IsActive).OrderBy(p => p.User.Email).ToList();
        //    }

        //    public void Add(Professor professor)
        //    {
        //        var userId = userRepository.Add(professor.User);
        //        professor.UserId = userId;
        //        professorRepository.Add(professor);
        //    }

        //    public void Update(int id, Professor professor)
        //    {
        //        userRepository.Update(professor.UserId, professor.User);
        //        professorRepository.Update(id, professor);
        //    }

        //    public void Delete(int id)
        //    {
        //        userRepository.Delete(id);
        //        professorRepository.Delete(id);
        //    }

        //    public List<User> ListAllStudents()
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}

