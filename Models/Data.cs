using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SR39_2021_pop2022_2.Services;
using SR39_2021_POP2022_2.Models;

namespace SR39_2021_pop2022_2.Models
{
    [Serializable]
    public class Data
    {
        [NonSerialized]
        private static Data instance;

        public List<User> Users { get; set; }
        public List<Professor> Professors { get; set; }
        public List<Student> Students { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Class> Classes { get; set; }




        static Data() { }

        private Data()
        {
            Users = new List<User>();
            Professors = new List<Professor>();
            Students = new List<Student>();
            Addresses = new List<Address>();
            Classes = new List<Class>();


        }

        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                }

                return instance;
            }

            private set => instance = value;
        }


        public void Initialize()
        {
            Address address = new Address
            {
                City = "Novi Sad",
                Country = "Srbija",
                Street = "ulica1",
                StreetNumber = "22",
                //Id = 1
            };
            Class @class = new Class
            {
                Id = 1,
                Name = "English",


            };

            User user1 = new User()
            {
                FirstName = "Pera",
                LastName = "Peric",
                Email = "pera@gmail.com",
                JMBG = "121346",
                Password = "peki",
                Gender = EGender.MALE,
                Address = address,
                UserType = EUserType.ADMINISTRATOR,
                IsActive = true
            };

            User user2 = new User
            {
                Email = "mika@gmail.com",
                FirstName = "mika",
                LastName = "Mikic",
                JMBG = "121346",
                Password = "zika",
                Gender = EGender.FEMALE,
                UserType = EUserType.PROFESSOR,
                IsActive = true,
                Address = address
            };

            User user3 = new User
            {
                Email = "zika@gmail.com",
                FirstName = "Zika",
                LastName = "Zikic",
                JMBG = "121346",
                Password = "zika",
                Gender = EGender.FEMALE,
                UserType = EUserType.STUDENT,
                IsActive = true,
                Address = address
            };

            Users.Add(user1);

            var professor = new Professor
            {
                User = user2
            };

            Professors.Add(professor);
            Classes.Add(@class);
        }

        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Config.dataFilePath, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, this);
            }

        }

        public static void Load()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(Config.dataFilePath, FileMode.Open, FileAccess.Read))
                {
                    Instance = (Data)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Instance = new Data();
            }

        }
    }
}
