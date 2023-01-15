using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Repositories;
using SR39_2021_POP2022_2.Models;
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

        public List<Class> GetAvailableClass()
        {
            return classRepository.GetAll().Where(p => p.IsDeleted).ToList();
        }

        public List<Class> GetAll()
        {
            return classRepository.GetAll();
        }

        public void Add(Class @class)
        {
            classRepository.Add(@class);
        }

        public void Update(int id, Class @class)
        {
            classRepository.Update(id, @class);
        }

        public void Delete(int id)
        {

            classRepository.Delete(id);
        }
    }
}
