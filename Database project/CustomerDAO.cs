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
    public class CustomerDAO
    {
        public IEnumerable<Customer> GetAll()
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

        public void Save(Customer c)
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

        public void Delete(int a)
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

        public void Update(Customer c)
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

        public void Import()
        {
            XmlDocument x = new XmlDocument();
            x.Load("data.xml");
            XmlNodeList CustomerNodes = x.SelectNodes("/data/customer");
            foreach (XmlNode cn in CustomerNodes)
            {
                string name = cn.SelectSingleNode("name").InnerText;
                string last_name = cn.SelectSingleNode("last_name").InnerText;
                string birth_date = cn.SelectSingleNode("birth_date").InnerText;

                Customer a = new Customer(name, last_name, birth_date);
                Save(a);
            }
        }
    }
}
