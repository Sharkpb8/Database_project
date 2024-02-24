using DAOTretak;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Database_project
{
    public class GenreDAO
    {
        public IEnumerable<Genre> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM genre", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Genre genre = new Genre(
                        Convert.ToInt32(reader[0].ToString()),
                        reader[1].ToString()
                    );
                    yield return genre;
                }
                reader.Close();
            }
        }

        public void Save(Genre g)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into genre (name) values (@name)", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", g.Name));
                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    g.ID = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
            }
        }

        public void Delete(int a)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM genre WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", a));
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
            }
        }

        public void Update(Genre g)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("update genre set name = @name " + "where id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", g.ID));
                command.Parameters.Add(new SqlParameter("@name", g.Name));
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
            }
        }

        public void Import()
        {
            XmlDocument x = new XmlDocument();
            x.Load("data.xml");
            XmlNodeList GenreNodes = x.SelectNodes("/data/genre");
            foreach (XmlNode gn in GenreNodes)
            {
                string name = gn.SelectSingleNode("name").InnerText;

                Genre a = new Genre(name);
                Save(a);
            }
        }
    }
}
