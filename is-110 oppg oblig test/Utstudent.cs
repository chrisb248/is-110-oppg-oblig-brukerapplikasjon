using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public class Utstudent : Student
    {
        public string HjemUniversitet { get; set; }
        public string Land { get; set; }

        public string PeriodeFraTil { get; set; }

        public Utstudent(int studentID, string studentnavn, string studentepost, string kurs, string hjemUniversitet, string land, string periodeFraTil)
            : base(studentID, studentnavn, studentepost, kurs)

        {
            HjemUniversitet = hjemUniversitet;
            Land = land;
            PeriodeFraTil = periodeFraTil;
        }
    }
}
