using Database_project;
using System.Net;
using System.Xml;


internal class Program
{
    private static void Main(string[] args)
    {
        Menu m = new Menu();
        Execute e = new Execute();
        bool running = true;
        while (running)
        {
            m.MenuOptions();
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Console.WriteLine(" ");
                    Console.WriteLine("Do které tabulky chcete vložit záznam");
                    m.TableOptions();
                    answer = Console.ReadLine();
                    e.Insert(answer);
                    break;
                case "2":
                    Console.WriteLine(" ");
                    Console.WriteLine("Ze které tabulky chcete smazat záznam");
                    m.TableOptions();
                    answer = Console.ReadLine();
                    e.Delete(answer);
                    break;
                case "3":
                    Console.WriteLine(" ");
                    Console.WriteLine("Ve které tabulce chcete upravit záznam");
                    m.TableOptions();
                    answer = Console.ReadLine();
                    e.Update(answer);
                    break;
                case "4":
                    Console.WriteLine(" ");
                    Console.WriteLine("Kterou tabulku chcete vypsat");
                    m.TableOptions();
                    answer = Console.ReadLine();
                    e.Read(answer);
                    break;
                case "5":
                    Console.WriteLine(" ");
                    Console.WriteLine("Do které tabulky chcete importovat data");
                    m.TableOptions();
                    Console.WriteLine("6. všech");
                    answer = Console.ReadLine();
                    e.Import(answer);
                    break;
                case "6":
                    Console.WriteLine(" ");
                    Console.WriteLine("Program se vypíná");
                    running = false;
                    break;
                default: 
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
    }
}