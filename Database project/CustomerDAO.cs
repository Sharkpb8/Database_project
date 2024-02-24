﻿using DAOTretak;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class CustomerDAO
    {
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
    }
}
