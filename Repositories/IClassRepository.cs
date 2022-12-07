using SR39_2021_pop2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Repositories
{
    interface IClassRepository
    {
        List<Class> GetAll();
        Class GetById(int id);
        int NextId(List<Class> lista);
        void Add(Class @class);
        void Add(List<Class> classes);
        void Set(List<Class> classes);
        void Update(int id, Class @class);
        void Delete(int id);

    }
}
