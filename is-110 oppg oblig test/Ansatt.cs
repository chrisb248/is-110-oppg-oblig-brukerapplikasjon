using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    // KRAV 7: Klasse  |  KRAV 9: Arv - Ansatt arver fra Person
    public class Ansatt : Person
    {
        public string Stilling { get; set; }
        public string Avdeling { get; set; }

        public Ansatt(int id, string navn, string epost, string stilling, string avdeling)
            : base(id, navn, epost)
        {
            Stilling = stilling;
            Avdeling = avdeling;
        }

        // KRAV 10: Polymorfisme - override gir annen output enn Student.VisInfo()
        public override string VisInfo()
        {
            return $"Ansatt {Id}: {Navn} ({Epost}) - Stilling: {Stilling}, Avdeling: {Avdeling}";
        }
    }
}
