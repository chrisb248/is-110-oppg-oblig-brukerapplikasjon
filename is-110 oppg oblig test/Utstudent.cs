using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public class Utstudent
    {
        public string HjemUniversitet { get; set; }
        public string Land { get; set; }

        public string PeriodeFraTil { get; set; }

        public Utstudent(string hjemUniversitet, string land, string periodeFraTil)
        {
            HjemUniversitet = hjemUniversitet;
            Land = land;
            PeriodeFraTil = periodeFraTil;
        }
    }
}
