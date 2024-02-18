﻿using System;
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
        private string release_date;

        public int ID { get => id; set => id = value; }
        public int Genre_id { get => genre_id; set => genre_id = value; }
        public int Autor_id { get => autor_id; set => autor_id = value; }
        public string Name { get => name; set => name = value; }
        public string Release_date { get => release_date; set => release_date = value; }

        public Book(int id,int genre_id,int autor_id, string name, string release_date)
        {
            this.ID = id;
            this.genre_id = genre_id;
            this.autor_id = autor_id;
            this.name = name;
            this.release_date = release_date;
        }

        public Book(int genre_id, int autor_id, string name, string release_date)
        {
            this.ID = 0;
            this.genre_id = genre_id;
            this.autor_id = autor_id;
            this.name = name;
            this.release_date = release_date;
        }

        public override string ToString()
        {
            return $"{ID}. {genre_id} {autor_id} {name} {release_date}";
        }
    }
}
