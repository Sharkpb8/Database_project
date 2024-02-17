﻿using System;
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
        private string birth_date;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Birth_date { get => birth_date; set => birth_date = value; }

        public Autor(int id, string name, string last_name, string birth_date)
        {
            this.ID = id;
            this.name = name;
            this.last_name = last_name;
            this.birth_date = birth_date;
        }

        public Autor(string name, string last_name, string birth_date)
        {
            this.ID = 0;
            this.name = name;
            this.last_name = last_name;
            this.birth_date = birth_date;
        }

        public override string ToString()
        {
            return $"{ID}. {name} {last_name} {birth_date}";
        }
    }
}
