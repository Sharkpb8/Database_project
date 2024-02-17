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
                    Console.WriteLine("List of autor");
                    foreach (Autor i in c.GetAll())
                    {
                        Console.WriteLine(i);
                    }
                }
                else if (answer == "2")
                {

                }
                else if(answer == "3")
                {

                }
                else if( answer == "4")
                {

                }
                else if(answer== "5")
                {

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