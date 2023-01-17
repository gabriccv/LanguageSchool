using SR39_2021_pop2022_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SR39_2021_POP2022_2.Models;
using System.Data;
using System.Net;
using System.Security.Claims;
using SR39_2021_pop2022_2.Services;

namespace SR39_2021_pop2022_2.Repositories
{
    class ClassRepository : IClassRepository
    {
        public ProfessorService professorService;
        public StudentService studentService;
        //private static List<Class> classes = new List<Class>();

        public int Add(Class @class)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();
                Console.WriteLine(@class.ProfessorId);
                Console.WriteLine(@class.Professor);
                Console.WriteLine(@class);
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Class (Name,DateOfClass,StartOfClass, ClassTime,Status,isDeleted, ProfessorId, StudentId)
                    output inserted.Id
                    values (@Name,@DateOfClass,@StartOfClass, @ClassTime,@Status,@isDeleted, @ProfessorId, @StudentId)";

                command.Parameters.Add(new SqlParameter("Name", @class.Name));
                command.Parameters.Add(new SqlParameter("DateOfClass", @class.DateOfClass));
                command.Parameters.Add(new SqlParameter("StartOfClass", @class.StartOfClass));
                command.Parameters.Add(new SqlParameter("ClassTime", @class.ClassTime));
                command.Parameters.Add(new SqlParameter("Status", @class.Status));
                command.Parameters.Add(new SqlParameter("isDeleted", @class.IsDeleted));
                command.Parameters.Add(new SqlParameter("ProfessorId",@class.Professor.UserId));
                command.Parameters.Add(new SqlParameter("StudentId",@class.Student.UserId));
                

               

                return (int)command.ExecuteScalar();
            }


        }




        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Class set IsDeleted=1 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }


        }

        public List<Class> GetAll()
        {
            List<Class> classes = new List<Class>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select c.Id,c.Name as className,c.DateOfClass,c.StartOfClass,c.ClassTime,c.Status,c.IsDeleted," +
                    "p.Id as pId,p.UserId as pUserId,u.FirstName as pFirstName,u.LastName as pLastName,u.Jmbg AS pJmbg," +
                    "u.Email As pEmail, u.Password as pPassword,u.Gender AS pGender,u.UserType as pUserType," +
                    "u.IsActive AS pIsActive,u.AddressId AS pAddressId,s.Id as sId,s.UserId as sUserId," +
                    "us.FirstName as sFirstName,us.LastName as sLastName,us.Jmbg AS sJmbg,us.Email As sEmail," +
                    " us.Password as sPassword,us.Gender AS sGender,us.UserType as sUserType,us.IsActive AS sIsActive," +
                    "us.AddressId AS sAddressId from dbo.Class c left join dbo.Users u  On c.ProfessorId=u.Id" +
                    " left join dbo.Professors p on p.UserId=u.Id left join dbo.Users us on c.StudentId=us.Id " +
                    "left join dbo.Students s on s.UserId=us.Id;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Class");

                foreach (DataRow row in ds.Tables["Class"].Rows)
                {
                    var pUser = new User
                    {
                        Id = (int)row["pUserId"],
                        FirstName = row["pFirstName"] as string,
                        LastName = row["pLastName"] as string,
                        Email = row["pEmail"] as string,
                        Password = row["pPassword"] as string,
                        JMBG = row["pJmbg"] as string,
                        Gender = (EGender)Enum.Parse(typeof(EGender), row["pGender"] as string),
                        UserType = (EUserType)Enum.Parse(typeof(EUserType), row["pUserType"] as string),
                        IsActive = (bool)row["pIsActive"],
                        AddressId =(int) row["pAddressId"] 
                    };
                    var sUser = new User
                    {
                        Id = (int)row["sUserId"],
                        FirstName = row["sFirstName"] as string,
                        LastName = row["sLastName"] as string,
                        Email = row["sEmail"] as string,
                        Password = row["sPassword"] as string,
                        JMBG = row["sJmbg"] as string,
                        Gender = (EGender)Enum.Parse(typeof(EGender), row["sGender"] as string),
                        UserType = (EUserType)Enum.Parse(typeof(EUserType), row["sUserType"] as string),
                        IsActive = (bool)row["sIsActive"],
                        AddressId = (int)row["sAddressId"]
                    };

                    var professor = new Professor
                    {
                        Id = (int)row["pId"],
                        User = pUser
                    };

                    var student = new Student
                    {
                        Id = (int)row["sId"],
                        User = sUser
                    };

                    var statusBool = (bool)row["Status"];
                    
                    
                    var @class = new Class
                    {
                        Id = (int)row["Id"],
                        Name = row["className"] as string,
                        DateOfClass = row["DateOfClass"] as string,
                        StartOfClass = row["StartOfClass"] as string,
                        ClassTime = row["ClassTime"] as string,
                        Status = statusBool ? EStatus.REZERVISAN : EStatus.SLOBODAN,
                        IsDeleted = (bool)row["IsDeleted"],
                        Professor=professor,
                        Student=student
                        
                    };
                    Console.WriteLine(@class.ProfessorId);
                    Console.WriteLine(@class.Professor);
                    Console.WriteLine(@class.Professor.UserId);

                    classes.Add(@class);
                }
            }

            return classes;
        }

        public Class GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Class where Id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Class");
                if (ds.Tables["Class"].Rows.Count > 0)
                {
                    var row = ds.Tables["Class"].Rows[0];

                    var @class = new Class
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"] as string,
                        DateOfClass = row["DateOfClass"] as string,
                        StartOfClass = row["StartOfClass"] as string,
                        ClassTime = row["ClassTime"] as string,
                        Status = (EStatus)Enum.Parse(typeof(EStatus), row["Status"] as string),
                        //ProfessorId = (int)row["ProfessorId"],
                        //StudentId = (int)row["StudentId"],
                        IsDeleted = (bool)row["IsDeleted"]
                    };

                    return @class;
                }
            }

            return null;
        }

        public void Update(int id, Class @class)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Class set 
                        Name = @Name,
                        DateOfClass = @DateOfClass,
                        StartOfClass = @StartOfClass,
                        ClassTime = @ClassTime,
                        Status = @Status,
                        ProfessoriD = @ProfessorId,
                        StudentId = @StudentId,
                        isDeleted = @isDeleted

                        where Id=@id";
                command.Parameters.Add(new SqlParameter("Id", @class.Id));
                command.Parameters.Add(new SqlParameter("Name", @class.Name));
                command.Parameters.Add(new SqlParameter("DateOfClass", @class.DateOfClass));
                command.Parameters.Add(new SqlParameter("StartOfClass", @class.StartOfClass));
                command.Parameters.Add(new SqlParameter("ClassTime", @class.ClassTime));
                command.Parameters.Add(new SqlParameter("Status", @class.Status));
                command.Parameters.Add(new SqlParameter("ProfessorId", @class.Professor.UserId));
                command.Parameters.Add(new SqlParameter("StudentId", @class.Student.UserId));
                command.Parameters.Add(new SqlParameter("isDeleted", @class.IsDeleted));

                command.ExecuteNonQuery();
            }

        }

        //public int NextId(List<Class> lista)
        //{
        //    int index=0;
        //    for(int i = 0; i <= lista.Count; i++)
        //    {
        //        if (index < i)
        //        {
        //            index= i;
        //        }
        //    }
        //    return ++index;
        //}


    }
}
