using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR39_2021_POP2022_2.Models;

namespace SR39_2021_pop2022_2.Repositories
{
    class SchoolRepository : ISchoolRepository
    {
        public AddressService addressService;
        public LanguageService languageService;


        public int Add(School school)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Schools (Name,AddressId,LanguageId, isDeleted)
                    output inserted.Id
                    values (@Name,@AddressId,@LanguageId,@isDeleted)";

                command.Parameters.Add(new SqlParameter("Name", school.Name));
                command.Parameters.Add(new SqlParameter("AddressId", school.AddressId));
                command.Parameters.Add(new SqlParameter("LanguageId", school.LanguageId));
                command.Parameters.Add(new SqlParameter("isDeleted", school.IsDeleted));




                return (int)command.ExecuteScalar();
            }


        }




        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Schools set IsDeleted=1 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }


        }

        public List<School> GetAll()
        {
            List<School> schools = new List<School>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select s.*,a.Street,a.StreetNumber,a.City,a.Country,a.IsDeleted as aIsDeleted," +
                    "l.NameOfLanguage,l.IsDeleted as lIsDeleted from dbo.Schools s " +
                    "left join dbo.Addresses a on s.AddressId=a.Id left join dbo.Languages l on s.LanguageId=l.Id ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "School");

                foreach (DataRow row in ds.Tables["School"].Rows)
                {
                    var address = new Address
                    {
                        Id = (int)row["AddressId"],
                        Street = row["Street"] as string,
                        StreetNumber = row["StreetNumber"] as string,
                        City = row["City"] as string,
                        Country = row["Country"] as string,
                        IsDeleted = (bool)row["aIsDeleted"]
                    };
                    var language = new Language
                    {
                        Id = (int)row["LanguageId"],
                        Name = row["NameOfLanguage"] as string,
                        IsDeleted = (bool)row["lIsDeleted"]
                    };


                    var school = new School
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"] as string,
                        Address = address,
                        Language = language,
                        IsDeleted = (bool)row["IsDeleted"]
                    };


                    schools.Add(school);
                }
            }

            return schools;
        }

        public School GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Schools where Id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "School");
                if (ds.Tables["School"].Rows.Count > 0)
                {
                    var row = ds.Tables["School"].Rows[0];

                    var school = new School
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"] as string,
                        IsDeleted = (bool)row["IsDeleted"]
                    };

                    return school;
                }
            }

            return null;
        }

        public void Update(int id, School school)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Schools set 
                        Name = @Name,
                        AddressId = @AddressId,
                        LanguageId = @LanguageId,
                        isDeleted = @isDeleted

                        where Id=@id";
                command.Parameters.Add(new SqlParameter("Id", school.Id));
                command.Parameters.Add(new SqlParameter("Name", school.Name));
                command.Parameters.Add(new SqlParameter("AddressId", school.AddressId));
                command.Parameters.Add(new SqlParameter("LanguageId", school.LanguageId));
                command.Parameters.Add(new SqlParameter("isDeleted", school.IsDeleted));

                command.ExecuteNonQuery();
            }

        }
    }
}
