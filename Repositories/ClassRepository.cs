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
    class ClassRepository : IClassRepository
    {
        //private static List<Class> classes = new List<Class>();

        public void Add(Class @class)
        {
            Data.Instance.Classes.Add(@class);
            Data.Instance.Save();
        }

        public void Add(List<Class> newClasses)
        {
            Data.Instance.Classes.AddRange(newClasses);
            Data.Instance.Save();
        }

        public void Set(List<Class> newClasses)
        {
            Data.Instance.Classes = newClasses;
        }

        public void Delete(int id)
        {
            Class @class = GetById(id);

            if (@class != null)
            {
                @class.IsDeleted = true;
            }

            Data.Instance.Save();
        }

        public List<Class> GetAll()
        {
            return Data.Instance.Classes;
        }

        public Class GetById(int id)
        {
            return Data.Instance.Classes.Find(u => u.Id == id);
        }

        public void Update(int id, Class updatedClass)
        {
            Data.Instance.Save();
        }

        public int NextId(List<Class> lista)
        {
            int index=0;
            for(int i = 0; i <= lista.Count; i++)
            {
                if (index < i)
                {
                    index= i;
                }
            }
            return ++index;
        }


    }
}
