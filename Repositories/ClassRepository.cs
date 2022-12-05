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
    class ClassRepository : IClassRepository, IFilePersistence
    {
        private static List<Class> listClasses = new List<Class>();
        public void Add(Class classs)
        {
            listClasses.Add(classs);
            Save();
        }

        public void Add(List<Class> classs)
        {
            listClasses.AddRange(classs);
            Save();
        }
        public void Set(List<Class> classs)
        {
            listClasses = classs;
        }

        public void Delete(string street)
        {
            Class classs = GetById(street);
            if (classs != null)
            {
                classs.IsDeleted = true;
                //listClasses.Remove(classs);
            }
            Save();
        }

        public List<Class> GetAll()
        {
            return listClasses;
        }

        public Class GetById(string gmail)
        {
            return listClasses.Find(c => c.Name == gmail);
        }
        public void Update(string street, Class classs)
        {
            Save();
        }

        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Config.classesFilePath, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, listClasses);
            }
        }

        public List<Class> Search(string sting)
        {
            throw new NotImplementedException();
        }


    }
}
