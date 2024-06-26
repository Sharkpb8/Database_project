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
    public class BookDAO
    {
        //výpis tabulky book
        public IEnumerable<Book> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM book", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book(
                        Convert.ToInt32(reader[0].ToString()),
                        Convert.ToInt32(reader[1].ToString()),
                        Convert.ToInt32(reader[2].ToString()),
                        Convert.ToInt32(reader[3].ToString()),
                        reader[4].ToString(),
                        reader[5].ToString()
                    );
                    yield return book;
                }
                reader.Close();
            }
        }

        //uložení do tabulky book
        public void Save(Book b)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into book (genre_id,autor_id,publisher_id,name,release_date) values (@genreid, @autorid,@publisherid,@name,@releasedate)", conn))
            {
                command.Parameters.Add(new SqlParameter("@genreid", b.Genre_id));
                command.Parameters.Add(new SqlParameter("@autorid", b.Autor_id));
                command.Parameters.Add(new SqlParameter("@publisherid", b.Publisher_id));
                command.Parameters.Add(new SqlParameter("@name", b.Name));
                command.Parameters.Add(new SqlParameter("@releasedate", b.Release_date));
                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    b.ID = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
            }
        }

        //smazání z tabulky book
        public void Delete(int a)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM book WHERE id = @id", conn))
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

        //update informace v tabulce book
        public void Update(Book b)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("update book set genre_id = @gi, autor_id = @ai,publisher_id = @pi, name = @name, release_date = @rd " + "where id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", b.ID));
                command.Parameters.Add(new SqlParameter("@gi", b.Genre_id));
                command.Parameters.Add(new SqlParameter("@ai", b.Autor_id));
                command.Parameters.Add(new SqlParameter("@pi", b.Publisher_id));
                command.Parameters.Add(new SqlParameter("@name", b.Name));
                command.Parameters.Add(new SqlParameter("@rd", b.Release_date));
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

        //importování do tabulky book
        public void Import()
        {
            try
            {
                XmlDocument x = new XmlDocument();
                x.Load("data.xml");
                XmlNodeList BookNodes = x.SelectNodes("/data/book");
                foreach (XmlNode bn in BookNodes)
                {
                    int genre_id = int.Parse(bn.SelectSingleNode("genre_id").InnerText);
                    int autor_id = int.Parse(bn.SelectSingleNode("autor_id").InnerText);
                    int publisher_id = int.Parse(bn.SelectSingleNode("publisher_id").InnerText);
                    string name = bn.SelectSingleNode("name").InnerText;
                    string release_date = bn.SelectSingleNode("release_date").InnerText;

                    Book a = new Book(genre_id, autor_id,publisher_id, name, release_date);
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
