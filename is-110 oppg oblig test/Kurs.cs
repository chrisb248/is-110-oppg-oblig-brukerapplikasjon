using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public class Kurs
    {
        public string Fagkode { get; set; }
        public string EmneNavn { get; set; }
        public int Studiepoeng { get; set; }
        public int StudentKapasitet { get; set; }
        

        public Kurs(string fagkode, string emneNavn, int studiepoeng, int studentKapasitet)
        {
            
            Fagkode = fagkode;
            EmneNavn = emneNavn;
            Studiepoeng = studiepoeng;
            StudentKapasitet = studentKapasitet;
        }
       



    }
}
