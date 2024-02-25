using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class Customer
    {
        private int id;
        private string name;
        private string last_name;
        private string email;

        //getter a setter pro všechny proměnné
        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Email { get => email; set => email = value; }

        /// <summary>
        /// Konstruktor třídy customer.
        /// </summary>
        public Customer(int id,string name,string last_name,string email)
        {
            this.ID = id;
            this.name = name;
            this.last_name = last_name;
            this.email = email;
        }

        /// <summary>
        /// Konstruktor třídy customer pro vytvoření instance s neznámým ID
        /// </summary>
        public Customer(string name, string last_name, string email)
        {
            this.ID = 0;
            this.name = name;
            this.last_name = last_name;
            this.email = email;
        }

        /// <summary>
        /// Překrytá metoda ToString pro zobrazení informací o zákazníku.
        /// </summary>
        /// <returns>Textový řetězec obsahující informace o zákazníku.</returns>
        public override string ToString()
        {
            return $"{ID}. {name} {last_name} {email}";
        }
    }
}
