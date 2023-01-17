using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR39_2021_pop2022_2.Models;

namespace SR39_2021_pop2022_2.Repositories
{
    class LanguageRepository : ILanguageRepository
    {
        public int Add(Language language)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Languages (NameOfLanguage,IsDeleted)
                    output inserted.Id
                    values (@NameOfLanguage, @IsDeleted)";

                command.Parameters.Add(new SqlParameter("NameOfLanguage", language.Name));
                command.Parameters.Add(new SqlParameter("IsDeleted", language.IsDeleted));

                return (int)command.ExecuteScalar();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Languages set IsDeleted=1 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }

        public List<Language> GetAll()
        {
            List<Language> languages = new List<Language>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Languages";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Languages");

                foreach (DataRow row in ds.Tables["Languages"].Rows)
                {
                    var language = new Language
                    {
                        Id = (int)row["Id"],
                        Name = row["NameOfLanguage"] as string,
                        IsDeleted = (bool)row["IsDeleted"]
                    };

                    languages.Add(language);
                }
            }

            return languages;
        }

        public Language GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Languages where Id={id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Languages");
                if (ds.Tables["Languages"].Rows.Count > 0)
                {
                    var row = ds.Tables["Languages"].Rows[0];

                    var language = new Language
                    {
                        Id = (int)row["Id"],
                        Name = row["NameOfLanguage"] as string,
                        IsDeleted = (bool)row["IsDeleted"]
                    };

                    return language;
                }
            }

            return null;
        }

        public void Update(int id, Language language)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Languages set 
                        NameOfLanguage = @NameOfLanguage 
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("NameOfLanguage", language.Name));

                command.ExecuteNonQuery();
            }
        }

    }
}
