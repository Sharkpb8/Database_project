using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_project
{
    public class Book
    {
        private int id;
        private int genre_id;
        private int autor_id;
        private string name;
        private string birth_date;

        public int ID { get => id; set => id = value; }
        public int Genre_id { get => genre_id; set => genre_id = value; }
        public int Autor_id { get => autor_id; set => autor_id = value; }
        public string Name { get => name; set => name = value; }
        public string Birth_date { get => birth_date; set => birth_date = value; }

        public Book(int id,int genre_id,int autor_id, string name, string birth_date)
        {
            this.ID = id;
            this.genre_id = genre_id;
            this.autor_id = autor_id;
            this.name = name;
            this.birth_date = birth_date;
        }

        public Book(string name, int genre_id, int autor_id, string birth_date)
        {
            this.ID = 0;
            this.genre_id = genre_id;
            this.autor_id = autor_id;
            this.name = name;
            this.birth_date = birth_date;
        }

        public override string ToString()
        {
            return $"{ID}. {genre_id} {autor_id} {name} {birth_date}";
        }
    }
}
