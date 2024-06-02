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
    public class BasketDAO
    {
        //výpis tabulky basket
        public IEnumerable<Basket> GetAll()
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

        //uložení do tabulky basket
        public void Save(Basket b)
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

        //smazání z tabulky basket
        public void Delete(int a)
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

        //update informace v tabulce basket
        public void Update(Basket b)
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

        //importování do tabulky basket
        public void Import()
        {
            try
            {
                XmlDocument x = new XmlDocument();
                x.Load("data.xml");
                XmlNodeList BasketNodes = x.SelectNodes("/data/basket");
                foreach (XmlNode bn in BasketNodes)
                {
                    int customer_id = int.Parse(bn.SelectSingleNode("customer_id").InnerText);
                    int book_id = int.Parse(bn.SelectSingleNode("book_id").InnerText);
                    string borrow_date = bn.SelectSingleNode("borrow_date").InnerText;
                    string ebt = Convert.ToString(bn.SelectSingleNode("ebt").InnerText);

                    Basket a = new Basket(customer_id, book_id, borrow_date, ebt);
                    Save(a);
                }
            }catch (Exception ex) 
            { 
                Console.WriteLine("Wrong format of file");
                Console.WriteLine("");
            }
        }
    }
}
