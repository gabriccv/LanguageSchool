//using SR39_2021_POP2022_2.Models;
//using SR39_2021_pop2022_2.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SR39_2021_pop2022_2.Models;

//namespace SR39_2021_pop2022_2.Services
//{
//    class SchoolService : ISchoolService
//    {
//        private ISchoolRepository schoolRepository;

//        public SchoolService()
//        {
//            schoolRepository = new SchoolRepository();
//        }
//        public List<School> GetValidScool()
//        {
//            return SchoolRepository.GetAll().Where(p => p.IsDeleted).ToList();
//        }

//        public List<School> GetAll()
//        {
//            return schoolRepository.GetAll();
//        }

//        public void Add(School school)
//        {
//            schoolRepository.Add(school);
//        }

//        public void Update(int id, School school)
//        {
//            schoolRepository.Update(id, school);
//        }
//        public void Delete(int id)
//        {

//            schoolRepository.Delete(id);
//        }
//    }
//}
