using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class Execute
    {
        AutorDAO Adao = new AutorDAO();
        GenreDAO GDAO = new GenreDAO();
        PublisherDAO PDAO = new PublisherDAO();
        BookDAO BoDAO = new BookDAO();
        CustomerDAO CDAO = new CustomerDAO();
        BasketDAO BaDAO = new BasketDAO();
        Menu m = new Menu();
        public void Insert(string answer)
        {
            if (answer == "1")
            {
                Console.WriteLine(" ");
                Console.Write("Jmeno autora: ");
                string name = Console.ReadLine();
                Console.Write("Příjmení autora: ");
                string last_name = Console.ReadLine();
                Console.Write("Datum narození autora: ");
                string birth_date = Console.ReadLine();
                Autor a = new Autor(name, last_name, birth_date);
                Adao.Save(a);
                Console.WriteLine(" ");
            }
            else if (answer == "2")
            {
                Console.WriteLine(" ");
                Console.Write("Jméno žánru: ");
                string name = Console.ReadLine();
                Genre a = new Genre(name);
                GDAO.Save(a);
                Console.WriteLine(" ");
            }
            else if(answer == "3")
            {
                Console.WriteLine(" ");
                Console.Write("Název vydavatele: ");
                string name = Console.ReadLine();
                Console.Write("Lokace vydavatele: ");
                string location = Console.ReadLine();
                Publisher a = new Publisher(name,location);
                PDAO.Save(a);
                Console.WriteLine(" ");
            }
            else if (answer == "4")
            {
                Console.WriteLine(" ");
                Console.Write("Id žánru: ");
                int genreid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Id autora: ");
                int autorid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Jmeno knihy: ");
                string name = Console.ReadLine();
                Console.Write("Den vydání: ");
                string releasedate = Console.ReadLine();
                Book a = new Book(genreid, autorid, name, releasedate);
                BoDAO.Save(a);
                Console.WriteLine(" ");
            }
            else if (answer == "5")
            {
                Console.WriteLine(" ");
                Console.Write("Id zákazníka: ");
                int customerid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Id knihy: ");
                int bookid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Den vypůjčení: ");
                string date = Console.ReadLine();
                Console.Write("Prodloužená doba vypujčení(a/n): ");
                string ebt = Console.ReadLine();
                if (ebt == "a")
                {
                    ebt = "1";
                }
                else if (ebt == "n")
                {
                    ebt = "0";
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
                Basket a = new Basket(customerid, bookid, date, ebt);
                BaDAO.Save(a);
                Console.WriteLine(" ");
            }
            else if (answer == "6")
            {
                Console.WriteLine(" ");
                Console.Write("Jmeno zákazníka: ");
                string name = Console.ReadLine();
                Console.Write("Příjmení zákazníka: ");
                string lastname = Console.ReadLine();
                Console.Write("Email zákazníka: ");
                string email = Console.ReadLine();
                Customer a = new Customer(name, lastname, email);
                CDAO.Save(a);
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }

        public void Delete(string answer)
        {
            if (answer == "1")
            {
                Console.WriteLine(" ");
                Console.Write("Zadajte id autora kterého chcete smazat: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Adao.Delete(id);
                Console.WriteLine(" ");
            }
            else if (answer == "2")
            {
                Console.WriteLine(" ");
                Console.Write("Zadajte id žánru který chcete smazat: ");
                int id = Convert.ToInt32(Console.ReadLine());
                GDAO.Delete(id);
                Console.WriteLine(" ");
            }
            else if (answer == "3")
            {
                Console.WriteLine(" ");
                Console.Write("Zadajte id vydavatele kterého chcete smazat: ");
                int id = Convert.ToInt32(Console.ReadLine());
                PDAO.Delete(id);
                Console.WriteLine(" ");
            }
            else if (answer == "4")
            {
                Console.WriteLine(" ");
                Console.Write("Zadajte id knihy kterou chcete smazat: ");
                int id = Convert.ToInt32(Console.ReadLine());
                BoDAO.Delete(id);
                Console.WriteLine(" ");
            }
            else if (answer == "5")
            {
                Console.WriteLine(" ");
                Console.Write("Zadajte id košíku který chcete smazat: ");
                int id = Convert.ToInt32(Console.ReadLine());
                BaDAO.Delete(id);
                Console.WriteLine(" ");
            }
            else if (answer == "6")
            {
                Console.WriteLine(" ");
                Console.Write("Zadajte id zákazníka kterého chcete smazat: ");
                int id = Convert.ToInt32(Console.ReadLine());
                CDAO.Delete(id);
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }

        public void Update(string answer)
        {
            if (answer == "1")
            {
                Console.WriteLine(" ");
                Console.Write("Zadejte id autora kterého chcete upravit: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Jmeno upraveného autora: ");
                string name = Console.ReadLine();
                Console.Write("Příjmení upraveného autora: ");
                string last_name = Console.ReadLine();
                Console.Write("Datum narození upraveného autora: ");
                string birth_date = Console.ReadLine();
                Autor a = new Autor(id, name, last_name, birth_date);
                Adao.Update(a);
                Console.WriteLine(" ");
            }
            else if (answer == "2")
            {
                Console.WriteLine(" ");
                Console.Write("Zadejte id žánru který chcete upravit: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Jméno upraveného žánru: ");
                string name = Console.ReadLine();
                Genre a = new Genre(id, name);
                GDAO.Update(a);
                Console.WriteLine(" ");
            }
            else if (answer == "3")
            {
                Console.WriteLine(" ");
                Console.Write("Zadejte id vydavatele kterého chcete upravit: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Jméno upraveného vydavatele: ");
                string name = Console.ReadLine();
                Console.Write("Jméno upravené lokality: ");
                string location = Console.ReadLine();
                Publisher a = new Publisher(id, name,location);
                PDAO.Update(a);
                Console.WriteLine(" ");
            }
            else if (answer == "4")
            {
                Console.WriteLine(" ");
                Console.Write("Zadejte id knihy kterou chcete upravit: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Id žánru: ");
                int genreid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Id autora: ");
                int autorid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Jmeno upravené knihy: ");
                string name = Console.ReadLine();
                Console.Write("Den vydání: ");
                string releasedate = Console.ReadLine();
                Book a = new Book(id, genreid, autorid, name, releasedate);
                BoDAO.Update(a);
                Console.WriteLine(" ");
            }
            else if (answer == "5")
            {
                Console.WriteLine(" ");
                Console.Write("Zadejte id košíku který chcete upravit: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Id zákazníka: ");
                int customerid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Id knihy: ");
                int bookid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Den vypůjčení: ");
                string date = Console.ReadLine();
                Console.Write("Prodloužená doba vypujčení(a/n): ");
                string ebt = Console.ReadLine();
                if (ebt == "a")
                {
                    ebt = "1";
                }
                else if (ebt == "n")
                {
                    ebt = "0";
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
                Basket a = new Basket(id, customerid, bookid, date, ebt);
                BaDAO.Update(a);
                Console.WriteLine(" ");
            }
            else if (answer == "6")
            {
                Console.WriteLine(" ");
                Console.Write("Zadejte id zákazníka kterého chcete upravit: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Jmeno upraveného zákazníka: ");
                string name = Console.ReadLine();
                Console.Write("Příjmení upraveného zákazníka: ");
                string lastname = Console.ReadLine();
                Console.Write("Email upraveného zákazníka: ");
                string email = Console.ReadLine();
                Customer a = new Customer(id, name, lastname, email);
                CDAO.Update(a);
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }

        public void Read(string answer)
        {
            switch(answer)
            {
                case "1":
                    Console.WriteLine(" ");
                    Console.WriteLine("List autorů");
                    foreach (Autor i in Adao.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine(" ");
                    break;
                case "2":
                    Console.WriteLine(" ");
                    Console.WriteLine("List žánrů");
                    foreach (Genre i in GDAO.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine(" ");
                    break;
                case "3":
                    Console.WriteLine(" ");
                    Console.WriteLine("List vydavatelu");
                    foreach (Publisher i in PDAO.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine(" ");
                    break;
                case "4":
                    Console.WriteLine(" ");
                    Console.WriteLine("List knih");
                    foreach (Book i in BoDAO.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine(" ");
                    break;
                case "5":
                    Console.WriteLine(" ");
                    Console.WriteLine("List košíků");
                    foreach (Basket i in BaDAO.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine(" ");
                    break;
                case "6":
                    Console.WriteLine(" ");
                    Console.WriteLine("List Zákazníků");
                    foreach (Customer i in CDAO.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine(" ");
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
        }

        public void Import(string answer)
        {
            switch (answer)
            {
                case "1":
                    Console.WriteLine(" ");
                    Adao.Import();
                    break;
                case "2":
                    Console.WriteLine(" ");
                    GDAO.Import();
                    break;
                case "3":
                    Console.WriteLine(" ");
                    PDAO.Import();
                    break;
                case "4":
                    Console.WriteLine(" ");
                    BoDAO.Import();
                    break;
                case "5":
                    Console.WriteLine(" ");
                    BaDAO.Import();
                    break;
                case "6":
                    Console.WriteLine(" ");
                    CDAO.Import();
                    break;
                case "7":
                    Console.WriteLine(" ");
                    Adao.Import();
                    GDAO.Import();
                    PDAO.Import();
                    BoDAO.Import();
                    BaDAO.Import();
                    CDAO.Import();
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            } 
        }
    }
}
