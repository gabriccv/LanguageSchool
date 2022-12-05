using SR39_2021_pop2022_2.Models;
using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Repositories
{
    interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(string email);
        void Add(Student student);
        void Add(List<Student> student);
        void Set(List<Student> student);
        void Update(string email, Student professor);
        void Delete(string email);
        List<User> Search(string sting);
    }
}
