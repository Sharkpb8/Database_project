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
                Console.WriteLine("List of autor");
                foreach (Autor i in c.GetAll())
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }
    }
}