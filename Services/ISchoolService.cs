using SR39_2021_pop2022_2.Models;
using SR39_2021_POP2022_2.Models;
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
        List<School> GetValidSchool();
        void Add(School school);

        void Update(int id, School school);
        void Delete(int id);
    }
}
