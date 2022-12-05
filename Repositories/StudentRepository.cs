using SR39_2021_pop2022_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SR39_2021_POP2022_2.Models;

namespace SR39_2021_pop2022_2.Repositories
{
    class StudentRepository : IStudentRepository, IFilePersistence
    {
        private static List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            students.Add(student);
            Save();
        }

        public void Add(List<Student> newStudent)
        {
            students.AddRange(newStudent);
            Save();
        }

        public void Set(List<Student> newStudent)
        {
            students = newStudent;
        }

        public void Delete(string email)
        {
            Student student = GetById(email);

            if (student != null)
            {
                //professor.User.IsActive = false;
                students.Remove(student);
            }

            Save();
        }
        //public void Delete(string email)
        //{
        //    Professor professor = GetById(email);

        //    if (professor != null)
        //    {
        //        professor.User.IsActive = false;
        //    }

        //    Save();
        //}

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(string email)
        {
            return students.Find(u => u.User.Email == email);
        }

        public void Update(string email, Student updatedProfessor)
        {
            Save();
        }

        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Config.professorsFilePath, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, students);
            }
        }

        public List<User> Search(string sting)
        {
            string lowerTerm = sting.ToLower();
            return Data.Instance.UserService.GetAll().Where(p => (p.FirstName.ToLower().Contains(lowerTerm)
            || p.LastName.ToLower().Contains(lowerTerm)) && !p.IsActive).ToList();
        }
    }
}

