using SR39_2021_pop2022_2.Models;
using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    interface IClassService
    {
        List<Class> GetAll();
        List<Class> GetAvailableClass();
        void Add(Class @class);
        void Update(int id, Class @class);
        void Delete(int id);


        //List<Class> GetAll();
        //Class GetById(int id);
        //List<Class> GetAvailableClasses();
        //List<Class> GetAvailableClassesByName(string name);
        //List<Class> GetAvailableClassesOrderedByName();
        //void Add(Class @class);
        //void Set(List<Class> classes);
        //void Update(int id, Class classes);
        //void Delete(int id);
    }
}
