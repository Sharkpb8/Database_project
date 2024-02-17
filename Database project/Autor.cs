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
        private string name;
        private string last_name;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Ĺast_name { get => last_name; set => last_name = value; }

        public Autor(int id, string name, string last_name)
        {
            this.ID = id;
            this.name = name;
            this.last_name = last_name;
        }

        public Autor(string name, string last_name)
        {
            this.ID = 0;
            this.name = name;
            this.last_name = last_name;
        }

        public override string ToString()
        {
            return $"{ID}. {name} {last_name}";
        }
    }
}
