// See https://aka.ms/new-console-template for more information
using is_110_oppg_oblig_test;
using System.Threading.Channels;

List<Student> students = new List<Student>();

var student1 = new Student(1, "Elias", "ELi@uia.no", "IS-110");
var student2 = new Student(2, "Ola", "ola@uia.no", "IS-112");

students.Add(student1);
students.Add(student2);

foreach (Student student in students)
{
    Console.WriteLine($"StudentID: {student.StudentID}, Navn: {student.StudentNavn}, E-post: {student.StudentEpost}, Kurs: {student.Kurs}");
}

//Utvekslingsstudent biten av å lage bruker og vise informasjon

List<Utstudent> utstudenter = new List<Utstudent>();

var utstudent1 = new Utstudent("Utvekslingsuniversitetet", "Utlandet", "August 2025 - Juni 2026");

utstudenter.Add(utstudent1);

foreach (Utstudent utstudent in utstudenter)
{
    Console.WriteLine($"Utvekslingsuniversitet: {utstudent.HjemUniversitet} Land: {utstudent.Land} Periode (fra-til): {utstudent.PeriodeFraTil}");
}

// Ansatt biten av å lage bruker og vise informasjon
List<Ansatt> ansatte = new List<Ansatt>();

var ansatt1 = new Ansatt(1, "Elias", "Eli@ansatt.no", "Foreleser", "Teknologi");

ansatte.Add(ansatt1);

foreach (Ansatt ansatt in ansatte)
{
    Console.WriteLine($"AnsattID: {ansatt.AnsattID} Ansatt navn: {ansatt.AnsattNavn} E-post: {ansatt.AnsattEpost} Stilling: {ansatt.Stilling} Avdeling: {ansatt.Avdeling} ");
}
// kurs biten av å lage kurs og vise informasjon
List<Kurs> kursene = new List<Kurs>();

var kurs1 = new Kurs("is-110", "C# programmering", 10, 50);
var kurs2 = new Kurs("is-112", "Java programmering", 5, 20);

kursene.Add(kurs1);
kursene.Add(kurs2);

foreach (Kurs kurs in kursene)
{
    Console.WriteLine($"Fagkode: {kurs.Fagkode} Kursnavn: {kurs.EmneNavn} studiepoing: {kurs.Studiepoeng} studentkapasitet {kurs.StudentKapasitet} ");
}
//liste med bøker 

List<Book> books = new List<Book>
{
    new Book("C# Programming", "John Smith", 2015, 29.99),
    new Book("Advanced C#", "Jane Doe", 2020, 49.99),
    new Book("Learn LINQ", "John Smith", 2012, 19.99),
    new Book("C# for Beginners", "Emily Clark", 2008, 9.99),
    new Book("Mastering LINQ", "John Smith", 2018, 39.99),
    new Book("LINQ in Action", "Joe Brown", 2017, 24.99)
};

string emneNavn = ""; // Declare and initialize emneNavn before the loop


while (true)
{
    Console.WriteLine();
    Console.WriteLine("1) opprette kurs");
    Console.WriteLine("2) melde studenter på og av kurs");
    Console.WriteLine("3) vis kurs og deltakere");         
    Console.WriteLine("4) søke på kurs");
    Console.WriteLine("5) søke på bøker");
    Console.WriteLine("6) låne ut "); // hindre utlån
    Console.WriteLine("7) lever inn bøker ");
    Console.WriteLine("8) vise aktive og lån og historikk");
    Console.WriteLine("9) registrere bøker");
    Console.WriteLine("10) avslutt");

    Console.Write("Choose:");
    var choice = Console.ReadLine();

    if (choice == "0") break;
    switch (choice)
    {
        case "1":
            // Felt for å registrere kurs m/ beskrivende tekst felt i terminal
            Console.WriteLine("Fyll ut feltene for å registrere kurs");
            Console.Write("Fagkode: ");
            string fagkode = Console.ReadLine()!;

            Console.Write("Emne navn: ");
            emneNavn = Console.ReadLine()!; // Assign value to emneNavn

            Console.Write("Studiepoeng: ");
            int studiePoeng = int.Parse(Console.ReadLine()!);

            Console.Write("Student kapasitet: ");
            int studentkapasitet = int.Parse(Console.ReadLine()!);

            var Kurs = new Kurs(fagkode, emneNavn, studiePoeng, studentkapasitet);
                kursene.Add(Kurs);

            // Vis bruker hva de har skrevet inn
            Console.WriteLine("\nTittel: " + fagkode);
            Console.WriteLine("Emne navn: " + emneNavn);
            Console.WriteLine($"Studiepoeng: {studiePoeng}");
            Console.WriteLine($"Student kapasitet: {studentkapasitet}");

            break;

        case "2": //"2) melde studenter på og av kurs

            Console.WriteLine("Fyll ut feltene for å melde studenter på kurs");
            Console.Write("studentID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Ugyldig studentID.");
                break;
            }

            var stud = students.Find(s => s.StudentID == studentId);
            if (stud == null)
            {
                Console.WriteLine("Student ikke funnet.");
                break;
            }

            Console.Write("kurs Fagkode (f.eks. is-110): ");
            string? kursKode = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(kursKode))
            {
                Console.WriteLine("Ugyldig kurs.");
                break;
            }

            var kursObj = kursene.Find(k => string.Equals(k.Fagkode, kursKode, StringComparison.OrdinalIgnoreCase));
            if (kursObj == null)
            {
                Console.WriteLine("Kurset finnes ikke.");
                break;
            }

            Console.Write("Trykk 1 for å melde på, 2 for å melde av: ");
            if (!int.TryParse(Console.ReadLine(), out int valg))
            {
                Console.WriteLine("Ugyldig valg.");
                break;
            }

            if (valg == 1)
            {
                // tell hvor mange som allerede har samme Kurs
                int påmeldte = students.Count(s => string.Equals(s.Kurs, kursObj.Fagkode, StringComparison.OrdinalIgnoreCase));
                if (påmeldte >= kursObj.StudentKapasitet)
                {
                    Console.WriteLine("Kurset er fullt.");
                }
                else
                {
                    stud.Kurs = kursObj.Fagkode; // OPPDATERER data — dette lagres i minnet
                    Console.WriteLine($"{stud.StudentNavn} (ID {stud.StudentID}) er meldt på {kursObj.Fagkode}.");
                }
            }
            else if (valg == 2)
            {
                if (string.Equals(stud.Kurs, kursObj.Fagkode, StringComparison.OrdinalIgnoreCase))
                {
                    stud.Kurs = ""; // fjern påmelding
                    Console.WriteLine($"Student {stud.StudentNavn} er meldt av {kursObj.Fagkode}.");
                }
                else
                {
                    Console.WriteLine("Student var ikke påmeldt dette kurset.");
                }
            }
            else
            {
                Console.WriteLine("Ugyldig valg.");
            }
            break;

        case "3": // vis kurs og deltakere (samlet)
            Console.WriteLine("kurs og påmeldte");
            foreach (var k in kursene)
            {
                // Finn studenter hvor Student.Kurs matcher kursets Fagkode
                Console.WriteLine($" {k.Fagkode}: {k.EmneNavn} (kapasitet: {k.StudentKapasitet})");
                Console.WriteLine("  Studenter meldt på dette kurset:");
                var påmeldte = students.Where(s => string.Equals(s.Kurs, k.Fagkode, StringComparison.OrdinalIgnoreCase)).ToList();
                if (påmeldte.Count == 0)
                {
                    Console.WriteLine("    Ingen påmeldte");
                }
                else
                {
                    foreach (var st in påmeldte)
                    {
                        Console.WriteLine($"    {st.StudentID}: {st.StudentNavn} ({st.StudentEpost})");
                    }
                }
            }
            break;

             case "4": // søke på kurs
            Console.Write("Search: ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                bool anyMatch = false;
                foreach (var book in books)
                {
                    // check title or author (case-insensitive)
                    if ((book.Title?.Contains(input, StringComparison.OrdinalIgnoreCase) ?? false)
                        || (book.Author?.Contains(input, StringComparison.OrdinalIgnoreCase) ?? false))
                    {
                        anyMatch = true;
                        Console.WriteLine("Match found:");
                        Console.WriteLine($"{book.Title} | {book.Author} | {book.Year} | {book.Price:C}");
                    }
                }

                if (!anyMatch)
                {
                    Console.WriteLine("No matches found.");
                }
            }
            else
            {
                Console.WriteLine("No search text entered.");
            }
            break;

        // case "5": // søke på bøker
        // case "6": // låne ut
        // case "7": // lever inn bøker
        // case "8": // vise aktive og lån og historikk
        // case "9": // registrere bøker
        case "10":
            Console.WriteLine("Tall for at du prukte programmet nå lukker det seg ha en fin dag");
            return; // avslutt
    }
}

