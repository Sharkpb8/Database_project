using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    internal class Publisher
    {
        private int id;
        private string name;
        private string location;

        //getter a setter pro všechny proměnné
        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Location { get => location; set => location = value; }

        /// <summary>
        /// Konstruktor třídy publisher.
        /// </summary>
        public Publisher(int id, string name, string location)
        {
            this.ID = id;
            this.name = name;
            this.location = location;
        }

        /// <summary>
        /// Konstruktor třídy publisher pro vytvoření instance s neznámým ID
        /// </summary>
        public Publisher(string name, string location)
        {
            this.ID = 0;
            this.name = name;
            this.location = location;
        }

        /// <summary>
        /// Překrytá metoda ToString pro zobrazení informací o publisheru.
        /// </summary>
        /// <returns>Textový řetězec obsahující informace o žánru.</returns>
        public override string ToString()
        {
            return $"{ID}. {name} {location}";
        }
    }
}
