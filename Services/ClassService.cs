using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    class ClassesService : IClassService
    {
        private ClassRepository classRepository;

        public ClassesService()
        {
            classRepository = new ClassRepository();
        }
        public void Add(Class classs)
        {
            classRepository.Add(classs);
        }

        public void Delete(string street)
        {
            classRepository.Delete(street);
        }

        public List<Class> GetAll()
        {
            return classRepository.GetAll();
        }

        public Class GetById(string street)
        {
            return classRepository.GetById(street);
        }

        public void Set(List<Class> classes)
        {
            classRepository.Set(classes);
        }

        public void Update(string street, Class classs)
        {
            classRepository.Update(street, classs);
        }
    }
}
