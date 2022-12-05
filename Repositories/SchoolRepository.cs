using SR39_2021_pop2022_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Repositories
{
    class SchoolRepository : ISchoolRepository, IFilePersistence
    {
        private static List<School> schools = new List<School>();
        public void Add(School school)
        {
            schools.Add(school);
            Save();
        }

        public void Add(List<School> school)
        {
            schools.AddRange(school);
            Save();
        }
        public void Set(List<School> newSchool)
        {
            schools = newSchool;
        }

        public void Delete(string name)
        {
            School school = GetById(name);
            if (school != null)
            {
                school.IsDeleted = true;
                //schools.Remove(school);
            }
            Save();
        }

        public List<School> GetAll()
        {
            return schools;
        }

        public School GetById(string email)
        {
            return schools.Find(s => s.Name == email);
        }

        public void Update(string name, School school)
        {
            Save();
        }

        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Config.schoolsFilePath, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, schools);
            }
        }
    }
}
