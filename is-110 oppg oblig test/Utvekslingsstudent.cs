using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    // KRAV 9: Arv - 3-nivå kjede: Utvekslingsstudent -> Student -> Person
    public class Utvekslingsstudent : Student
    {
        public string HjemUniversitet { get; set; }
        public string Land { get; set; }
        public string PeriodeFraTil { get; set; }

        public Utvekslingsstudent(int id, string navn, string epost, string kurs, string hjemUniversitet, string land, string periodeFraTil)
            : base(id, navn, epost, kurs)
        {
            HjemUniversitet = hjemUniversitet;
            Land = land;
            PeriodeFraTil = periodeFraTil;
        }

        // KRAV 10: Polymorfisme - overskriver Student sin VisInfo() med ekstra info
        public override string VisInfo()
        {
            return $"Utvekslingsstudent {Id}: {Navn} ({Epost}) - Kurs: {Kurs}, Hjem: {HjemUniversitet}, Land: {Land}, Periode: {PeriodeFraTil}";
        }
    }
}
