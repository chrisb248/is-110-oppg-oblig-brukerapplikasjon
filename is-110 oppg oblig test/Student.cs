using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    // KRAV 7: Klasse  |  KRAV 9: Arv - Student arver fra Person
    public class Student : Person
    {
        // KRAV 2: Auto-implementert egenskap
        public string Kurs { get; set; }

        public Student(int id, string navn, string epost, string kurs)
            : base(id, navn, epost)
        {
            Kurs = kurs;
        }

        // KRAV 10: Polymorfisme - override av abstrakt metode fra Person
        public override string VisInfo()
        {
            return $"Student {Id}: {Navn} ({Epost}) - Kurs: {Kurs}";
        }
    }
}
