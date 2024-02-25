﻿using DAOTretak;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Database_project
{
    public class AutorDAO
    {
        //výpis tabulky autor
        public IEnumerable<Autor> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM autor", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Autor autor = new Autor(
                        Convert.ToInt32(reader[0].ToString()),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString()
                    ); ;
                    yield return autor;
                }
                reader.Close();
            }
        }

        //uložení do tabulky autor
        public void Save(Autor a)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into autor (name, last_name, birth_date) values (@name, @lastname,@birthdate)", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", a.Name));
                command.Parameters.Add(new SqlParameter("@lastname", a.Last_name));
                command.Parameters.Add(new SqlParameter("@birthdate", a.Birth_date));
                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    a.ID = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
            }
        }

        //smazání z tabulky autor
        public void Delete(int a)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM autor WHERE id = @id", conn))
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

        //update informace v tabulce autor
        public void Update(Autor a)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("update autor set name = @name, last_name = @lastname, birth_date = @birthdate " + "where id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", a.ID));
                command.Parameters.Add(new SqlParameter("@name", a.Name));
                command.Parameters.Add(new SqlParameter("@lastname", a.Last_name));
                command.Parameters.Add(new SqlParameter("@birthdate", a.Birth_date));
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

        //importování do tabulky autor
        public void Import()
        {
            try { 
            XmlDocument x = new XmlDocument();
            x.Load("data.xml");
            XmlNodeList AutorNodes = x.SelectNodes("/data/autor");
            foreach (XmlNode an in AutorNodes)
            {
                string name = an.SelectSingleNode("name").InnerText;
                string lastName = an.SelectSingleNode("last_name").InnerText;
                string birthDate = an.SelectSingleNode("birth_date").InnerText;

                Autor a = new Autor(name, lastName, birthDate);
                Save(a);
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
