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
                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    autor.ID = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
            }
        }

        public void SaveGenre(Genre genre)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into genre (name) values (@name)", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", genre.Name));
                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    genre.ID = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
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

        public void SaveCustomer(Customer c)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into customer (name,last_name,email) values (@name, @lastname,@email)", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", c.Name));
                command.Parameters.Add(new SqlParameter("@lastname", c.Last_name));
                command.Parameters.Add(new SqlParameter("@email", c.Email));
                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    c.ID = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
            }
        }

        public void SaveBasket(Basket b)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into basket (customer_id,book_id,borrow_date,extended_borrow_time) values (@customerid, @bookid,@bd,@ebt)", conn))
            {
                command.Parameters.Add(new SqlParameter("@customerid", b.Customer_id));
                command.Parameters.Add(new SqlParameter("@bookid", b.Book_id));
                command.Parameters.Add(new SqlParameter("@bd", b.Date));
                command.Parameters.Add(new SqlParameter("@ebt", b.Ebt));
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

        public void DeleteAutor(int a)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM autor WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", a));
                try
                {
                    command.ExecuteNonQuery();
                }catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong parametrs");
                }
                
            }
        }

        public void DeleteGenre(int a)
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

        public void DeleteBook(int a)
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

        public void DeleteCustomer(int a)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM customer WHERE id = @id", conn))
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

        public void DeleteBasket(int a)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM basket WHERE id = @id", conn))
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

        public void UpdateAutor(Autor autor)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("update autor set name = @name, last_name = @lastname, birth_date = @birthdate " + "where id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", autor.ID));
                command.Parameters.Add(new SqlParameter("@name", autor.Name));
                command.Parameters.Add(new SqlParameter("@lastname", autor.Last_name));
                command.Parameters.Add(new SqlParameter("@birthdate", autor.Birth_date));
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

        public void UpdateGenre(Genre g)
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

        public void UpdateBook(Book b)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("update book set genre_id = @gi, autor_id = @ai, name = @name, release_date = @rd " + "where id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", b.ID));
                command.Parameters.Add(new SqlParameter("@gi", b.Genre_id));
                command.Parameters.Add(new SqlParameter("@ai", b.Autor_id));
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

        public void UpdateCustomer(Customer c)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("update customer set name = @name, last_name = @lastname, email = @email " + "where id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", c.ID));
                command.Parameters.Add(new SqlParameter("@name", c.Name));
                command.Parameters.Add(new SqlParameter("@lastname", c.Last_name));
                command.Parameters.Add(new SqlParameter("@email", c.Email));
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

        public void UpdateBasket(Basket b)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("update basket set customer_id = @ci, book_id = @bi, borrow_date = @bd, extended_borrow_time = @ebt " + "where id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", b.ID));
                command.Parameters.Add(new SqlParameter("@ci", b.Customer_id));
                command.Parameters.Add(new SqlParameter("@bi", b.Book_id));
                command.Parameters.Add(new SqlParameter("@bd", b.Date));
                command.Parameters.Add(new SqlParameter("@ebt", b.Ebt));
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
    }
}
