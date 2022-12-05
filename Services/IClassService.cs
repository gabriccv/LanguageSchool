using SR39_2021_pop2022_2.Models;
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
        Class GetById(string street);
        void Add(Class classs);
        void Set(List<Class> classes);
        void Update(string street, Class classs);
        void Delete(string street);
    }
}
