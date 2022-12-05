using SR39_2021_pop2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    interface ISchoolService
    {
        List<School> GetAll();
        School GetById(string name);
        List<School> GetActiveSchools();
        void Add(School school);
        void Set(List<School> schools);
        void Update(string name, School school);
        void Delete(string name);
        List<School> Search(string email);
    }
}
