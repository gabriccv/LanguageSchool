using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    class ClassService : IClassService
    {
        private IClassRepository classRepository;

        public ClassService()
        {
            classRepository = new ClassRepository();

        }

        public Class GetById(int id)
        {
            return classRepository.GetById(id);
        }

        public List<Class> GetAll()
        {
            return classRepository.GetAll();
        }

        public List<Class> GetAvailableClasses()
        {
            return classRepository.GetAll().Where(p => !p.IsDeleted).ToList();
        }



        public void Add(Class calss)
        {
            if (calss.Id == 0)
            {
                calss.Id = classRepository.NextId(classRepository.GetAll());
            }
            classRepository.Add(calss);

        }

        public void Set(List<Class> classes)
        {
            classRepository.Set(classes);
        }

        public void Update(int id, Class @class)
        {
            classRepository.Update(id, @class);

        }

        public void Delete(int id)
        {

            classRepository.Delete(id);
        }

        public List<Class> ListAllClasses()
        {
            throw new NotImplementedException();
        }

        public List<Class> GetAvailableClassesByName(string name)
        {
            return classRepository.GetAll().Where(p => !p.IsDeleted && p.Name.Contains(name)).ToList();
        }

        public List<Class> GetAvailableClassesOrderedByName()
        {
            return classRepository.GetAll().Where(p => !p.IsDeleted).OrderBy(p => p.Name).ToList();
        }
    }
}
