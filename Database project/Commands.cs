using DAOTretak;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class Commands
    {
        public IEnumerable<Autor> GetAllAutor()
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
                        reader[2].ToString()
                    );
                    yield return autor;
                }
                reader.Close();
            }
        }

        public IEnumerable<Genre> GetAllGenre()
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

        public IEnumerable<Book> GetAllBook()
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
                        reader[3].ToString(),
                        reader[4].ToString()
                    );
                    yield return book;
                }
                reader.Close();
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM customer", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer(
                        Convert.ToInt32(reader[0].ToString()),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString()

                    );
                    yield return customer;
                }
                reader.Close();
            }
        }
    }
}
