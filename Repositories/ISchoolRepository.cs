using SR39_2021_pop2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Repositories
{
    interface ISchoolRepository
    {
        List<School> GetAll();
        School GetById(string email);
        void Add(School school);
        void Add(List<School> school);
        void Set(List<School> school);
        void Update(string name, School school);
        void Delete(string name);
    }
}
