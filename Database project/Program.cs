using Database_project;
using System.Net;
using System.Xml;


internal class Program
{
    private static void Main(string[] args)
    {
        AutorDAO Adao = new AutorDAO();
        GenreDAO GDAO = new GenreDAO();
        BookDAO BoDAO = new BookDAO();
        CustomerDAO CDAO = new CustomerDAO();
        BasketDAO BaDAO = new BasketDAO();
        Menu m = new Menu();
        while (true)
        {
            m.MenuOptions();
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                m.TableOptions();
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    m.Space();
                    Console.Write("Jmeno autora: ");
                    string name = Console.ReadLine();
                    Console.Write("Příjmení autora: ");
                    string last_name = Console.ReadLine();
                    Console.Write("Datum narození autora: ");
                    string birth_date = Console.ReadLine();
                    Autor a = new Autor(name, last_name, birth_date);
                    Adao.Save(a);
                    m.Space();
                }
                else if (answer == "2")
                {
                    m.Space();
                    Console.Write("Jméno žánru: ");
                    string name = Console.ReadLine();
                    Genre a = new Genre(name);
                    GDAO.Save(a);
                    m.Space();
                }
                else if (answer == "3")
                {
                    m.Space();
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
                    m.Space();
                }
                else if (answer == "4")
                {
                    m.Space();
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
                        m.Wrong();
                    }
                    Basket a = new Basket(customerid, bookid, date, ebt);
                    BaDAO.Save(a);
                    m.Space();
                }
                else if (answer == "5")
                {
                    m.Space();
                    Console.Write("Jmeno zákazníka: ");
                    string name = Console.ReadLine();
                    Console.Write("Příjmení zákazníka: ");
                    string lastname = Console.ReadLine();
                    Console.Write("Email zákazníka: ");
                    string email = Console.ReadLine();
                    Customer a = new Customer(name, lastname, email);
                    CDAO.Save(a);
                    m.Space();
                }
                else
                {
                    m.Wrong();
                }
            }
            else if (answer == "2")
            {
                m.TableOptions();
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    m.Space();
                    Console.Write("Zadajte id autora kterého chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Adao.Delete(id);
                    m.Space();
                }
                else if (answer == "2")
                {
                    m.Space();
                    Console.Write("Zadajte id žánru který chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    GDAO.Delete(id);
                    m.Space();
                }
                else if (answer == "3")
                {
                    m.Space();
                    Console.Write("Zadajte id knihy kterou chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    BoDAO.Delete(id);
                    m.Space();
                }
                else if (answer == "4")
                {
                    m.Space();
                    Console.Write("Zadajte id košíku který chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    BaDAO.Delete(id);
                    m.Space();
                }
                else if (answer == "5")
                {
                    m.Space();
                    Console.Write("Zadajte id zákazníka kterého chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    CDAO.Delete(id);
                    m.Space();
                }
                else
                {
                    m.Wrong();
                }
            }
            else if (answer == "3")
            {
                m.TableOptions();
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    m.Space();
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
                    m.Space();
                }
                else if (answer == "2")
                {
                    m.Space();
                    Console.Write("Zadejte id žánru který chcete upravit: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Jméno upraveného žánru: ");
                    string name = Console.ReadLine();
                    Genre a = new Genre(id, name);
                    GDAO.Update(a);
                    m.Space();
                }
                else if (answer == "3")
                {
                    m.Space();
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
                    m.Space();
                }
                else if (answer == "4")
                {
                    m.Space();
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
                        m.Wrong();
                    }
                    Basket a = new Basket(id, customerid, bookid, date, ebt);
                    BaDAO.Update(a);
                    m.Space();
                }
                else if (answer == "5")
                {
                    m.Space();
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
                    m.Space();
                }
                else
                {
                    m.Wrong();
                }
            }
            else if (answer == "4")
            {
                m.TableOptions();
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    m.Space();
                    Console.WriteLine("List autorů");
                    foreach (Autor i in Adao.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    m.Space();
                }
                else if (answer == "2")
                {
                    m.Space();
                    Console.WriteLine("List žánrů");
                    foreach (Genre i in GDAO.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    m.Space();
                }
                else if (answer == "3")
                {
                    m.Space();
                    Console.WriteLine("List knih");
                    foreach (Book i in BoDAO.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    m.Space();
                }
                else if (answer == "4")
                {
                    m.Space();
                    Console.WriteLine("List košíků");
                    foreach (Basket i in BaDAO.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    m.Space();
                }
                else if (answer == "5")
                {
                    m.Space();
                    Console.WriteLine("List Zákazníků");
                    foreach (Customer i in CDAO.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                    m.Space();
                }
                else
                {
                    m.Wrong();
                }
            }
            else if (answer == "5")
            {
                m.TableOptions();
                Console.WriteLine("6.všech");
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    Adao.Import();
                }
                else if (answer == "2")
                {
                    GDAO.Import();
                }
                else if (answer == "3") 
                {
                    BoDAO.Import();
                }
                else if (answer == "4")
                {
                    BaDAO.Import();
                }
                else if (answer == "5")
                {
                    CDAO.Import();
                }
                else if(answer == "6")
                {
                    Adao.Import();
                    GDAO.Import();
                    BoDAO.Import();
                    BaDAO.Import();
                    CDAO.Import();
                }
                else
                {
                    m.Wrong();
                }
                Console.WriteLine("Informace byly uspěšně vloženy");
            }
            else
            {
                m.Wrong();
            }
        }
    }
}