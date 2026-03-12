using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentNavn { get; set; }
        public string StudentEpost { get; set; }
        public string Kurs { get; set; }

        public Student(int studentID, string studentnavn, string studentepost, string kurs)
        {
            StudentID = studentID;
            StudentNavn = studentnavn;
            StudentEpost = studentepost;
            Kurs = kurs;
        }

        public void VisInformasjon()
        {
            Console.WriteLine($"StudentID: {StudentID} Navn: {StudentNavn}");
        }
    }
}
