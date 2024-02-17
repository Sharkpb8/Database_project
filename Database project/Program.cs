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
                    Autor a = new Autor(name,last_name,birth_date);
                    c.SaveAutor(a);
                    Console.WriteLine("");
                }
                else if (answer == "2")
                {

                }
                else if (answer == "3")
                {

                }
                else if (answer == "4")
                {

                }
                else if (answer == "5")
                {

                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            } 
            else if (answer == "2")
            {

            } 
            else if(answer == "3")
            {

            }
            else if(answer == "4")
            {
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