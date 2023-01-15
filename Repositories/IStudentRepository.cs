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
        Student GetById(int id);
        int Add(Student student);
        //void Add(List<Student> students);
        //void Set(List<Student> students);
        void Update(int id, Student student);
        void Delete(int id);

    }
}
