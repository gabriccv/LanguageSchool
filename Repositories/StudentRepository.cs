using SR39_2021_pop2022_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SR39_2021_POP2022_2.Models;
using System.Data.SqlClient;
using System.Data;
using SR39_2021_pop2022_2.Services;
using Microsoft.VisualBasic.ApplicationServices;
using User = SR39_2021_POP2022_2.Models.User;

namespace SR39_2021_pop2022_2.Repositories
{
    class StudentRepository : IStudentRepository
    {
        private IAddressRepository addressRepository;
        public int Add(Student student)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Students (UserId)
                    output inserted.Id
                    values (@UserId)";

                command.Parameters.Add(new SqlParameter("UserId", student.UserId));

                return (int)command.ExecuteScalar();
            }
        }

        //public void Add(List<Student> newStudents)
        //{
        //    Data.Instance.Students.AddRange(newStudents);
        //    Data.Instance.Save();
        //}

        //public void Set(List<Student> newStudents)
        //{
        //    Data.Instance.Students = newStudents;
        //}

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Users set IsActive=0 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }


        }
        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select s.UserId, u.* , a.* FROM dbo.Students s, dbo.Users u LEFT JOIN dbo.Addresses a " +  
                    "ON u.AddressId = a.Id where s.UserId = u.id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Students");

                foreach (DataRow row in ds.Tables["Students"].Rows)
                {
                    var address = new Address
                    {
                        Id = (int)row["Id"],
                        Street = row["Street"] as string,
                        StreetNumber = row["StreetNumber"] as string,
                        City = row["City"] as string,
                        Country = row["Country"] as string,
                        IsDeleted = (bool)row["IsDeleted"]
                    };

                    var user = new User
                    {
                        Id = (int)row["UserId"],
                        FirstName = row["FirstName"] as string,
                        LastName = row["LastName"] as string,
                        Email = row["Email"] as string,
                        Password = row["Password"] as string,
                        JMBG = row["Jmbg"] as string,
                        Gender = (EGender)Enum.Parse(typeof(EGender), row["Gender"] as string),
                        UserType = (EUserType)Enum.Parse(typeof(EUserType), row["UserType"] as string),
                        IsActive = (bool)row["IsActive"],
                        AddressId = (int)row["AddressId"],
                        Address=address
                        
                };

                    var student = new Student
                    {
                        Id = (int)row["id"],
                        User = user
                    };

                    students.Add(student);
                }
            }

            return students;
        }


        public Student GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Students s, dbo.Users u where s.UserId=u.id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Students");

                if (ds.Tables["Students"].Rows.Count > 0)
                {
                    var row = ds.Tables["Students"].Rows[0];

                    var user = new User
                    {
                        Id = (int)row["Id"],
                        FirstName = row["FirstName"] as string,
                        LastName = row["LastName"] as string,
                        Email = row["Email"] as string,
                        Password = row["Password"] as string,
                        JMBG = row["Jmbg"] as string,
                        Gender = (EGender)Enum.Parse(typeof(EGender), row["Gender"] as string),
                        UserType = (EUserType)Enum.Parse(typeof(EUserType), row["UserType"] as string),
                        IsActive = (bool)row["IsActive"],
                        AddressId = (int)row["AddressId"]
                    };

                    var student = new Student
                    {
                        User = user
                    };

                    return student;
                }
            }
            return null;
        }
        

        public void Update(int id, Student student)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Students set 
                        UserId = @UserId 
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("UserId", student.UserId));

                command.ExecuteScalar();
            }
             

        }
    }
    
}

