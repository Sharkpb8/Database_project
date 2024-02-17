using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class Autor
    {
        private int id;
        private string jmeno;
        private string prijmeni;

        public int ID { get => id; set => id = value; }
        public string Jmeno { get => jmeno; set => jmeno = value; }
        public string Prijmeni { get => prijmeni; set => prijmeni = value; }

        public Autor(int id, string jmeno, string prijmeni)
        {
            this.ID = id;
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
        }

        public Autor(string jmeno, string prijmeni)
        {
            this.ID = 0;
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
        }

        public override string ToString()
        {
            return $"{ID}. {jmeno} {prijmeni}";
        }
    }
}
