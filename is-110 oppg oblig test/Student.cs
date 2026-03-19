using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public class Student : Person
    {
        public string Kurs { get; set; }

        public Student(int studentID, string studentnavn, string studentepost, string kurs)
            : base(studentID, studentnavn, studentepost)
        {
            Kurs = kurs;
        }

        public override string VisInfo()
        {
            return $"{Id}: {Navn} ({Epost}) - Kurs: {Kurs}";
        }
    }
}
