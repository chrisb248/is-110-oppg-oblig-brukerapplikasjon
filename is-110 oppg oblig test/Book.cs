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

        // KRAV 3: Tilgangsmodifikator - private felt skjuler data, public property gir tilgang med validering
        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0) throw new ArgumentException("Pris kan ikke være negativ.");
                _price = value;
            }
        }

        public bool IsAvailable { get; set; } = true;

        public Book(string title, string author, int year, double price)
        {
            Title = title;
            Author = author;
            Year = year;
            Price = price;
        }
    }
}
