using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class Genre
    {
        private int id;
        private string name;

        //getter a setter pro všechny proměnné
        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Konstruktor třídy genre.
        /// </summary>
        public Genre(int id, string name)
        {
            this.ID = id;
            this.name = name;
        }

        /// <summary>
        /// Konstruktor třídy genre pro vytvoření instance s neznámým ID
        /// </summary>
        public Genre(string name)
        {
            this.ID = 0;
            this.name = name;
        }

        /// <summary>
        /// Překrytá metoda ToString pro zobrazení informací o žánru.
        /// </summary>
        /// <returns>Textový řetězec obsahující informace o žánru.</returns>
        public override string ToString()
        {
            return $"{ID}. {name} ";
        }
    }
}
