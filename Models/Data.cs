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
    sealed class Data
    {
        private static readonly Data instance = new Data();
        public IUserService UserService { get; set; }
        public IProfessorService ProfessorService { get; set; }
        public IStudentService StudentService { get; set; }
        public IAddressService AddressService { get; set; }
        public ISchoolService SchoolService { get; set; }
        public IClassService ClassService { get; set; }

        static Data() { }

        private Data()
        {
            UserService = new UserService();
            ProfessorService = new ProfessorService();
            StudentService = new StudentService();
            AddressService = new AddressService();
            SchoolService = new SchoolService();
            ClassService = new ClassesService();
        }

        public static Data Instance
        {
            get
            {
                return instance;
            }
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

            UserService.Add(user1);
            ProfessorService.Add(user2);
        }

        public void LoadData()
        {
            var users = LoadUsers();
            var professors = LoadProfessors();
            var students = LoadStudents();
            var addresses = LoadAddresses();
            var schools = LoadSchools();
            var classes = LoadClasses();

            foreach (var professor in professors)
            {
                var user = users.Find(u => u.Email == professor.UserId);
                professor.User = user;
            }

            foreach (var student in students)
            {
                var user = users.Find(u => u.Email == student.UserId);
                student.User = user;
            }
            UserService.Set(users);
            ProfessorService.Set(professors);
            StudentService.Set(students);
            AddressService.Set(addresses);
            SchoolService.Set(schools);
            ClassService.Set(classes);
        }

        private List<User> LoadUsers()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();

                using (Stream stream = new FileStream(Config.usersFilePath, FileMode.Open, FileAccess.Read))
                {
                    return (List<User>)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                return new List<User>();
            }
        }

        private List<Professor> LoadProfessors()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(Config.professorsFilePath, FileMode.Open, FileAccess.Read))
                {
                    return (List<Professor>)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                return new List<Professor>();
            }

        }

        private List<Student> LoadStudents()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(Config.studentsFilePath, FileMode.Open, FileAccess.Read))
                {
                    return (List<Student>)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                return new List<Student>();
            }

        }

        private List<Address> LoadAddresses()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(Config.addressesFilePath, FileMode.Open, FileAccess.Read))
                {
                    return (List<Address>)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                return new List<Address>();
            }

        }

        private List<School> LoadSchools()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(Config.schoolsFilePath, FileMode.Open, FileAccess.Read))
                {
                    return (List<School>)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                return new List<School>();
            }

        }

        private List<Class> LoadClasses()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(Config.classesFilePath, FileMode.Open, FileAccess.Read))
                {
                    return (List<Class>)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                return new List<Class>();
            }

        }
    }
}
