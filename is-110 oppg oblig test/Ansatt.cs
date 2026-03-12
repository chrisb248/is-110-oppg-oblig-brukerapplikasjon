using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public class Ansatt
    {
        public int AnsattID { get; set; }
        public string AnsattNavn { get; set; }
        public string AnsattEpost { get; set; }
        public string Stilling { get; set; }
        public string Avdeling { get; set; }

        public Ansatt(int ansattID, string ansattNavn, string ansattEpost, string stilling, string avdeling)
        {
            AnsattID = ansattID;
            AnsattNavn = ansattNavn;
            AnsattEpost = ansattEpost;
            Stilling = stilling;
            Avdeling = avdeling;
        }
    }
}
