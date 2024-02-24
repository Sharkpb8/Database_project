﻿using DAOTretak;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class BasketDAO
    {
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
