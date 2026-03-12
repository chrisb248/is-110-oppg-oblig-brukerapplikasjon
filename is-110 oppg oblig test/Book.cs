using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
        public double Price { get; set; }

        public Book(string title, string author, int year, double price)
        {
            Title = title;
            Author = author;
            Year = year;
            Price = price;
        }

    }
}
