using SR39_2021_pop2022_2.Models;
using SR39_2021_POP2022_2.Models;
//using SR39_2021_pop2022_2.Repositories.SR39_2021_POP2022.Repositories;
using SR39_2021_pop2022_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    class StudentService : IStudentService
    {
        private IStudentRepository studentRepository;
        private IUserRepository userRepository;

        public StudentService()
        {
            studentRepository = new StudentRepository();
            userRepository = new UserRepository();
        }

        public Student GetById(int id)
        {
            return studentRepository.GetById(id);
        }

        public List<Student> GetAll()
        {
            return studentRepository.GetAll();
        }

        public List<Student> GetActiveStudents()
        {
            return studentRepository.GetAll().Where(p => p.User.IsActive).ToList();
        }

        public List<Student> GetActiveStudentsByEmail(string email)
        {
            return studentRepository.GetAll().Where(p => p.User.IsActive && p.User.Email.Contains(email)).ToList();
        }
        public List<Student> GetActiveStudentsOrderedByEmail()
        {
            return studentRepository.GetAll().Where(p => p.User.IsActive).OrderBy(p => p.User.Email).ToList();
        }

        public void Add(Student student)
        {
            var userId = userRepository.Add(student.User);
            student.UserId = userId;
           studentRepository.Add(student);
        }

        public void Update(int id, Student student)
        {
            userRepository.Update(student.UserId, student.User);
            studentRepository.Update(id, student);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
            studentRepository.Delete(id);
        }

        public List<User> ListAllProfessors()
        {
            throw new NotImplementedException();
        }
    }
}

