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
        Class GetById(string gmail);
        void Add(Class classs);
        void Add(List<Class> classs);
        void Set(List<Class> classs);
        void Update(string street, Class classs);
        void Delete(string street);
        List<Class> Search(string sting);
    }
}
