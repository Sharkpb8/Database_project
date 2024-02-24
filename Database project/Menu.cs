using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class Menu
    {
        public void MenuOptions()
        {
            Console.WriteLine("1. Vložit do databáze");
            Console.WriteLine("2. Smazat z databáze");
            Console.WriteLine("3. Úprava záznamu");
            Console.WriteLine("4. výpis databáze");
            Console.WriteLine("5. vložit do databáze ze souboru");
        }

        public void TableOptions()
        {
            Space();
            Console.WriteLine("Do které tabulky chcete vložit záznam");
            Console.WriteLine("1. autor");
            Console.WriteLine("2. žánr");
            Console.WriteLine("3. knihy");
            Console.WriteLine("4. košík");
            Console.WriteLine("5. zákazník");
        }

        public void Space()
        {
            Console.WriteLine(" ");
        }

        public void Wrong()
        {
            Console.WriteLine("Wrong input");
        }
    }
}
