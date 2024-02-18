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
                        reader[2].ToString(),
                        reader[3].ToString()
                    ); ;
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

        public IEnumerable<Basket> GetAllBasket()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM basket", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Basket basket = new Basket(
                        Convert.ToInt32(reader[0].ToString()),
                        Convert.ToInt32(reader[1].ToString()),
                        Convert.ToInt32(reader[2].ToString()),
                        reader[3].ToString(),
                        reader[4].ToString()

                    );
                    yield return basket;
                }
                reader.Close();
            }
        }

        public void SaveAutor(Autor autor)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

                using (command = new SqlCommand("insert into autor (name, last_name, birth_date) values (@name, @lastname,@birthdate)", conn))
                {
                    command.Parameters.Add(new SqlParameter("@name", autor.Name));
                    command.Parameters.Add(new SqlParameter("@lastname", autor.Last_name));
                    command.Parameters.Add(new SqlParameter("@birthdate", autor.Birth_date));
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    autor.ID = Convert.ToInt32(command.ExecuteScalar());
                }
        }

        public void SaveGenre(Genre genre)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into genre (name) values (@name)", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", genre.Name));
                command.ExecuteNonQuery();
                command.CommandText = "Select @@Identity";
                genre.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void SaveBook(Book b)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into book (genre_id,autor_id,name,release_date) values (@genreid, @autorid,@name,@releasedate)", conn))
            {
                command.Parameters.Add(new SqlParameter("@genreid", b.Genre_id));
                command.Parameters.Add(new SqlParameter("@autorid", b.Autor_id));
                command.Parameters.Add(new SqlParameter("@name", b.Name));
                command.Parameters.Add(new SqlParameter("@releasedate", b.Release_date));
                command.ExecuteNonQuery();
                command.CommandText = "Select @@Identity";
                b.ID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
