using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class Basket
    {
        private int id;
        private int customer_id;
        private int book_id;
        private string date;
        private string ebt;

        //getter a setter pro všechny proměnné
        public int ID { get => id; set => id = value; }
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public int Book_id { get => book_id; set => book_id = value; }
        public string Date { get => date; set => date = value; }
        public string Ebt { get => ebt; set => ebt = value; }

        /// <summary>
        /// Konstruktor třídy basket.
        /// </summary>
        public Basket(int id, int customer_id,int book_id, string date, string ebt)
        {
            this.ID = id;
            this.customer_id = customer_id;
            this.book_id = book_id;
            this.date = date;
            this.ebt = ebt;
        }

        /// <summary>
        /// Konstruktor třídy basket pro vytvoření instance s neznámým ID
        /// </summary>
        public Basket(int customer_id, int book_id, string date, string ebt)
        {
            this.ID = 0;
            this.customer_id = customer_id;
            this.book_id = book_id;
            this.date = date;
            this.ebt = ebt;
        }

        /// <summary>
        /// Překrytá metoda ToString pro zobrazení informací o košíku.
        /// </summary>
        /// <returns>Textový řetězec obsahující informace o košíku.</returns>
        public override string ToString()
        {
            return $"{ID}. {customer_id} {book_id} {date} {ebt}";
        }
    }
}
