using Database_project;

internal class Program
{
    private static void Main(string[] args)
    {
        Commands c = new Commands();
        while (true)
        {
            Console.WriteLine("1. Vložit do databáze");
            Console.WriteLine("2. Smazat z databáze");
            Console.WriteLine("3. Úprava záznamu");
            Console.WriteLine("4. výpis databáze");
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.WriteLine("");
                Console.WriteLine("Do které tabulky chcete vložit záznam");
                Console.WriteLine("1. autor");
                Console.WriteLine("2. žánr");
                Console.WriteLine("3. knihy");
                Console.WriteLine("4. košík");
                Console.WriteLine("5. zákazník");
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("");
                    Console.Write("Jmeno autora: ");
                    string name = Console.ReadLine();
                    Console.Write("Příjmení autora: ");
                    string last_name = Console.ReadLine();
                    Console.Write("Datum narození autora: ");
                    string birth_date = Console.ReadLine();
                    Autor a = new Autor(name, last_name, birth_date);
                    c.SaveAutor(a);
                    Console.WriteLine("");
                }
                else if (answer == "2")
                {
                    Console.WriteLine("");
                    Console.Write("Jméno žánru: ");
                    string name = Console.ReadLine();
                    Genre a = new Genre(name);
                    c.SaveGenre(a);
                    Console.WriteLine("");
                }
                else if (answer == "3")
                {
                    Console.WriteLine("");
                    Console.Write("Id žánru: ");
                    int genreid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Id autora: ");
                    int autorid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Jmeno knihy: ");
                    string name = Console.ReadLine();
                    Console.Write("Den vydání: ");
                    string releasedate = Console.ReadLine();
                    Book a = new Book(genreid, autorid, name, releasedate);
                    c.SaveBook(a);
                    Console.WriteLine("");
                }
                else if (answer == "4")
                {
                    Console.WriteLine("");
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
                    c.SaveBasket(a);
                    Console.WriteLine("");
                }
                else if (answer == "5")
                {
                    Console.WriteLine("");
                    Console.Write("Jmeno zákazníka: ");
                    string name = Console.ReadLine();
                    Console.Write("Příjmení zákazníka: ");
                    string lastname = Console.ReadLine();
                    Console.Write("Email zákazníka: ");
                    string email = Console.ReadLine();
                    Customer a = new Customer(name, lastname, email);
                    c.SaveCustomer(a);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
            else if (answer == "2")
            {
                Console.WriteLine("");
                Console.WriteLine("Ze které tabulky chcete smazat záznam");
                Console.WriteLine("1. autor");
                Console.WriteLine("2. žánr");
                Console.WriteLine("3. knihy");
                Console.WriteLine("4. košík");
                Console.WriteLine("5. zákazník");
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("");
                    Console.Write("Zadajte id autora kterého chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    c.DeleteAutor(id);
                    Console.WriteLine("");
                }
                else if (answer == "2")
                {
                    Console.WriteLine("");
                    Console.Write("Zadajte id žánru který chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    c.DeleteGenre(id);
                    Console.WriteLine("");
                }
                else if (answer == "3")
                {
                    Console.WriteLine("");
                    Console.Write("Zadajte id knihy kterou chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    c.DeleteBook(id);
                    Console.WriteLine("");
                }
                else if (answer == "4")
                {
                    Console.WriteLine("");
                    Console.Write("Zadajte id košíku který chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    c.DeleteBasket(id);
                    Console.WriteLine("");
                }
                else if (answer == "5")
                {
                    Console.WriteLine("");
                    Console.Write("Zadajte id zákazníka kterého chcete smazat: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    c.DeleteCustomer(id);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
            }
            else if (answer == "3")
            {
                Console.WriteLine("");
                Console.WriteLine("Ve které tabulce chcete upravit záznam");
                Console.WriteLine("1. autor");
                Console.WriteLine("2. žánr");
                Console.WriteLine("3. knihy");
                Console.WriteLine("4. košík");
                Console.WriteLine("5. zákazník");
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("");
                    Console.Write("Zadejte id autora kterého chcete upravit: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Jmeno upraveného autora: ");
                    string name = Console.ReadLine();
                    Console.Write("Příjmení upraveného autora: ");
                    string last_name = Console.ReadLine();
                    Console.Write("Datum narození upraveného autora: ");
                    string birth_date = Console.ReadLine();
                    Autor a = new Autor(id,name, last_name, birth_date);
                    c.UpdateAutor(a);
                    Console.WriteLine("");
                }
                else if (answer == "2")
                {
                    Console.WriteLine("");
                    Console.Write("Zadejte id žánru který chcete upravit: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Jméno upraveného žánru: ");
                    string name = Console.ReadLine();
                    Genre a = new Genre(id,name);
                    c.UpdateGenre(a);
                    Console.WriteLine("");
                }
                else if (answer == "3")
                {
                    Console.WriteLine("");
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
                    Book a = new Book(id,genreid, autorid, name, releasedate);
                    c.UpdateBook(a);
                    Console.WriteLine("");
                }
                else if (answer == "4")
                {
                    Console.WriteLine("");
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
                    Basket a = new Basket(id,customerid, bookid, date, ebt);
                    c.UpdateBasket(a);
                    Console.WriteLine("");
                }
                else if (answer == "5")
                {
                    Console.WriteLine("");
                    Console.Write("Zadejte id zákazníka kterého chcete upravit: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Jmeno upraveného zákazníka: ");
                    string name = Console.ReadLine();
                    Console.Write("Příjmení upraveného zákazníka: ");
                    string lastname = Console.ReadLine();
                    Console.Write("Email upraveného zákazníka: ");
                    string email = Console.ReadLine();
                    Customer a = new Customer(id,name, lastname, email);
                    c.UpdateCustomer(a);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
            else if(answer == "4")
            {
                Console.WriteLine("");
                Console.WriteLine("Kterou tabulku chcete vypsat");
                Console.WriteLine("1. autor");
                Console.WriteLine("2. žánr");
                Console.WriteLine("3. knihy");
                Console.WriteLine("4. košík");
                Console.WriteLine("5. zákazník");
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("");
                    Console.WriteLine("List autorů");
                    foreach (Autor i in c.GetAllAutor())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("");
                }
                else if (answer == "2")
                {
                    Console.WriteLine("");
                    Console.WriteLine("List žánrů");
                    foreach (Genre i in c.GetAllGenre())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("");
                }
                else if(answer == "3")
                {
                    Console.WriteLine("");
                    Console.WriteLine("List knih");
                    foreach (Book i in c.GetAllBook())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("");
                }
                else if( answer == "4")
                {
                    Console.WriteLine("");
                    Console.WriteLine("List košíků");
                    foreach (Basket i in c.GetAllBasket())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("");
                }
                else if(answer== "5")
                {
                    Console.WriteLine("");
                    Console.WriteLine("List Zákazníků");
                    foreach (Customer i in c.GetAllCustomers())
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }
    }
}