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
    public class PublisherDAO
    {
        ////výpis tabulky publisher
        public IEnumerable<Publisher> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM publisher", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Publisher p = new Publisher(
                        Convert.ToInt32(reader[0].ToString()),
                        reader[1].ToString(),
                        reader[2].ToString()
                    );
                    yield return p;
                }
                reader.Close();
            }
        }

        //uložení do tabulky publisher
        public void Save(Publisher p)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into publisher (name,location) values (@name, @location)", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", p.Name));
                command.Parameters.Add(new SqlParameter("@location", p.Location));
                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    p.ID = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
            }
        }

        //smazání z tabulky publisher
        public void Delete(int a)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM publisher WHERE id = @id", conn))
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

        //update informace v tabulce publisher
        public void Update(Publisher p)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("update publisher set name = @name, location = @location" + "where id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", p.ID));
                command.Parameters.Add(new SqlParameter("@name", p.Name));
                command.Parameters.Add(new SqlParameter("@location", p.Location));
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

        //importování do tabulky publisher
        public void Import()
        {
            try
            {
                XmlDocument x = new XmlDocument();
                x.Load("data.xml");
                XmlNodeList PublisherNodes = x.SelectNodes("/data/publisher");
                foreach (XmlNode pn in PublisherNodes)
                {
                    string name = pn.SelectSingleNode("name").InnerText;
                    string location = pn.SelectSingleNode("location").InnerText;

                    Publisher p = new Publisher(name,location);
                    Save(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong format of file");
                Console.WriteLine("");
            }
        }
    }
}
