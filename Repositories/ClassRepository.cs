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

namespace SR39_2021_pop2022_2.Repositories
{
    class ClassRepository : IClassRepository
    {
        //private static List<Class> classes = new List<Class>();

        public int Add(Class @class)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.lessons (Name,DateOfClass,StartOfClass, ClassTime,Status, ProfessorId, StudentId,isDeleted)
                    output inserted.Id
                    values (@Name,@DateOfClass,@StartOfClass, @ClassTime,@Status, @ProfessorId, @StudentId,@isDeleted)";

                command.Parameters.Add(new SqlParameter("Name", @class.Name));
                command.Parameters.Add(new SqlParameter("DateOfClass", @class.DateOfClass));
                command.Parameters.Add(new SqlParameter("StartOfClass", @class.StartOfClass));
                command.Parameters.Add(new SqlParameter("ClassTime", @class.ClassTime));
                command.Parameters.Add(new SqlParameter("Status", @class.Status));
                command.Parameters.Add(new SqlParameter("ProfessorId", (object)@class.ProfessorId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("StudentId", (object)@class.StudentId ?? DBNull.Value));
                command.Parameters.Add(new SqlParameter("isDeleted", @class.IsDeleted));

                return (int)command.ExecuteScalar();
            }


        }




        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Lessons set IsDeleted=1 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }


        }

        public List<Class> GetAll()
        {
            List<Class> classes = new List<Class>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Lessons";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Lessons");

                foreach (DataRow row in ds.Tables["Lessons"].Rows)
                {
                    var @class = new Class
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"] as string,
                        DateOfClass = row["DateOfClass"] as string,
                        StartOfClass = row["StartOfClass"] as string,
                        ClassTime = row["ClassTime"] as string,
                        Status = (EStatus)Enum.Parse(typeof(EStatus), row["Status"] as string),
                        ProfessorId = (int)row["ProfessorId"],
                        StudentId = (int)row["StudentId"],
                        IsDeleted = (bool)row["IsDeleted"]
                    };

                    classes.Add(@class);
                }
            }

            return classes;
        }

        public Class GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Lessons where Id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Lessons");
                if (ds.Tables["Lessons"].Rows.Count > 0)
                {
                    var row = ds.Tables["Lessons"].Rows[0];

                    var @class = new Class
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"] as string,
                        DateOfClass = row["DateOfClass"] as string,
                        StartOfClass = row["StartOfClass"] as string,
                        ClassTime = row["ClassTime"] as string,
                        Status = (EStatus)Enum.Parse(typeof(EStatus), row["Status"] as string),
                        ProfessorId = (int)row["ProfessorId"],
                        StudentId = (int)row["StudentId"],
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
                command.CommandText = @"update dbo.Lessons set 
                        Name = @Name,
                        DateOfClass = @DateOfClass,
                        StartOfClass = @StartOfClass,
                        ClassTime = @ClassTime,
                        Status = @Status,
                        ProfessoriD = @ProfessorId
                        StudentId = @StudentId
                        isDeleted = @isDeleted

                        where Id=@id";
                command.Parameters.Add(new SqlParameter("Name", @class.Name));
                command.Parameters.Add(new SqlParameter("DateOfClass", @class.DateOfClass));
                command.Parameters.Add(new SqlParameter("StartOfClass", @class.StartOfClass));
                command.Parameters.Add(new SqlParameter("ClassTime", @class.ClassTime));
                command.Parameters.Add(new SqlParameter("Status", @class.Status));
                command.Parameters.Add(new SqlParameter("ProfessorId", @class.ProfessorId ));
                command.Parameters.Add(new SqlParameter("StudentId", @class.StudentId ));
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
