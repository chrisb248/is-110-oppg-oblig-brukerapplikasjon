using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public class Ansatt : Person
    {
        public string Stilling { get; set; }
        public string Avdeling { get; set; }

        public Ansatt(int ansattID, string ansattNavn, string ansattEpost, string stilling, string avdeling)
            : base(ansattID, ansattNavn, ansattEpost)
        {
            Stilling = stilling;
            Avdeling = avdeling;
        }

        public override string VisInfo()
        {
            return $"{Id}: {Navn} ({Epost}) - Stilling: {Stilling}, Avdeling: {Avdeling}";
        }
    }
}
