using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    class SchoolService : ISchoolService
    {
        private ISchoolRepository schoolRepository;

        public SchoolService()
        {
            schoolRepository = new SchoolRepository();
        }
        public School GetById(string name)
        {
            return schoolRepository.GetById(name);
        }
        public List<School> GetAll()
        {
            return schoolRepository.GetAll();
        }
        public void Add(School school)
        {
            schoolRepository.Add(school);
        }
        public void Set(List<School> schools)
        {
            schoolRepository.Set(schools);
        }
        public void Update(string name, School school)
        {
            schoolRepository.Update(name, school);
        }
        public void Delete(string name)
        {
            schoolRepository.Delete(name);
        }
        public List<School> GetActiveSchools()
        {
            return schoolRepository.GetAll().Where(s => s.IsDeleted == false).ToList();
        }
        public List<School> Search(string email)
        {
            throw new NotImplementedException();
        }


    }
}
