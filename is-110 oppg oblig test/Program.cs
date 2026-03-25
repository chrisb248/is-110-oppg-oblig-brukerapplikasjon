// See https://aka.ms/new-console-template for more information
using is_110_oppg_oblig_test;
using System.Threading.Channels;

// KRAV 4: Kolleksjoner - List<T> for å holde mange objekter
// KRAV 1: Variabler og datatyper - int, string, double, bool, DateTime
List<Student> students = new List<Student>();

// KRAV 7: Objekter - oppretter instanser av klassen Student
var student1 = new Student(1, "Elias", "ELi@uia.no", "IS-110");
var student2 = new Student(2, "Ola", "ola@uia.no", "IS-112");
var student3 = new Student(3, "Kari", "kari@uia.no", "IS-110");

students.Add(student1);
students.Add(student2);
students.Add(student3);

//Utvekslingsstudent biten av å lage bruker og vise informasjon

List<Utvekslingsstudent> utstudenter = new List<Utvekslingsstudent>();

var utstudent1 = new Utvekslingsstudent(100, "Lise", "lise@uia.no", "IS-110", "Utvekslingsuniversitetet", "Utlandet", "August 2025 - Juni 2026");
var utstudent2 = new Utvekslingsstudent(101, "Markus", "markus@uia.no", "IS-112", "Utvekslingsuniversitetet", "Utlandet", "August 2025 - Juni 2026");

utstudenter.Add(utstudent1);


// Ansatt biten av å lage bruker og vise informasjon
List<Ansatt> ansatte = new List<Ansatt>();

var ansatt1 = new Ansatt(1, "Elias", "Eli@ansatt.no", "Foreleser", "Teknologi");
var ansatt2 = new Ansatt(2, "Ola", "ola@ansatt.no","foreleser", "gruppesykologi");

ansatte.Add(ansatt1);

// kurs biten av å lage kurs og vise informasjon
List<Kurs> kursene = new List<Kurs>();

var kurs1 = new Kurs("is-110", "C# programmering", 10, 50);
var kurs2 = new Kurs("is-112", "Java programmering", 5, 20);

kursene.Add(kurs1);
kursene.Add(kurs2);



//liste med bøker 

List <Book> books = new List<Book>
{
    new Book("C# Programming", "John Smith", 2015, 29.99),
    new Book("Advanced C#", "Jane Doe", 2020, 49.99),
    new Book("Learn LINQ", "John Smith", 2012, 19.99),
    new Book("C# for Beginners", "Emily Clark", 2008, 9.99),
    new Book("Mastering LINQ", "John Smith", 2018, 39.99),
    new Book("LINQ in Action", "Joe Brown", 2017, 24.99)
};

List<Loan> loans = new List<Loan>();

string emneNavn = ""; // Declare and initialize emneNavn before the loop



// KRAV 5: Løkke - while-løkke for hovedmenyen
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
    Console.WriteLine("10) Vis all studenter lærere og utvekslingsstudenter");
    Console.WriteLine("11) registrer ny student");
    Console.WriteLine("12) registrer ny ansatt");
    Console.WriteLine("13) registrer ny utvekslingsstudent");
    Console.WriteLine("14) avslutt");

    Console.Write("Choose:");
    var choice = Console.ReadLine();

    if (choice == "0") break;
    // KRAV 6: IF-betingelser - switch/case for menyvalg
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

            var stud = students.Find(s => s.Id == studentId);
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
                    Console.WriteLine($"{stud.Navn} (ID {stud.Id}) er meldt på {kursObj.Fagkode}.");
                }
            }
            else if (valg == 2)
            {
                if (string.Equals(stud.Kurs, kursObj.Fagkode, StringComparison.OrdinalIgnoreCase))
                {
                    stud.Kurs = ""; // fjern påmelding
                    Console.WriteLine($"Student {stud.Navn} er meldt av {kursObj.Fagkode}.");
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
                Console.WriteLine("  --------------------------------------");
                var påmeldte = students.Where(s => string.Equals(s.Kurs, k.Fagkode, StringComparison.OrdinalIgnoreCase)).ToList();
                if (påmeldte.Count == 0)
                {
                    Console.WriteLine("    Ingen påmeldte");
                }
                else
                {
                    foreach (var st in påmeldte)
                    {
                        Console.WriteLine($"    {st.Id}: {st.Navn} ({st.Epost})");
                    }
                }
            }
            break;

             case "4": // søke på kurs
    Console.Write("Search course (code or name): ");
    string? søke = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(søke))
    {
        // KRAV 8: LINQ query-syntaks med where, orderby og select
        var kursResultater = from k in kursene
                             where (k.Fagkode?.Contains(søke, StringComparison.OrdinalIgnoreCase) ?? false)
                                || (k.EmneNavn?.Contains(søke, StringComparison.OrdinalIgnoreCase) ?? false)
                             orderby k.Fagkode
                             select k;

        bool any = false;
        foreach (var k in kursResultater)
        {
            any = true;
            Console.WriteLine($"{k.Fagkode} | {k.EmneNavn} | Studiepoeng: {k.Studiepoeng} | Kapasitet: {k.StudentKapasitet}");
        }
        if (!any) Console.WriteLine("No course matches found.");
    }
    else
    {
        Console.WriteLine("No search text entered.");
    }
    break;

         case "5": // søke på bøker
             Console.Write("Search books (title or author): ");
            string? search = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(search))
            {
                // KRAV 8: LINQ method-syntaks med Where, OrderBy og Select (projeksjon)
                var bokResultater = books
                    .Where(b => (b.Title?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false)
                             || (b.Author?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false))
                    .OrderBy(b => b.Title)
                    .Select(b => new { b.Title, b.Author, b.Year, b.Price, Status = b.IsAvailable ? "Tilgjengelig" : "Utlånt" })
                    .ToList();

                if (bokResultater.Count == 0)
                {
                    Console.WriteLine("No books match found.");
                }
                else
                {
                    foreach (var b in bokResultater)
                    {
                        Console.WriteLine($"{b.Title} by {b.Author} ({b.Year}) - ${b.Price} [{b.Status}]");
                    }
                }
            }
            else
            {
                Console.WriteLine("No search text entered.");
            }
            break;

         case "6": // låne ut
                
            Console.WriteLine("Låne ut bok:");
            Console.Write("StudentID: ");
            if (int.TryParse(Console.ReadLine(), out int lånerId))
            {
                var lånerStudent = students.Find(s => s.Id == lånerId);

                if (lånerStudent == null)
                {
                    Console.WriteLine("Student ikke funnet.");
                }
                else
                {
                    Console.WriteLine($"Student funnet: {lånerStudent.Navn}");

                    Console.WriteLine("\nTilgjengelige bøker:");
                    var tilgjengeligeBøker = books.Where(b => b.IsAvailable).ToList();

                    if (tilgjengeligeBøker.Count == 0)
                    {
                        Console.WriteLine("Ingen bøker er tilgjengelige for utlån.");
                    }
                    else
                    {
                        for (int i = 0; i < tilgjengeligeBøker.Count; i++)
                        {
                            var b = tilgjengeligeBøker[i];
                            Console.WriteLine($"{i + 1}. {b.Title} av {b.Author} ({b.Year}) - {b.Price} kr");
                        }

                        Console.Write("\nVelg bok nummer: ");
                        if (!int.TryParse(Console.ReadLine(), out int bokNr))
                        {
                            Console.WriteLine("Ugyldig input. Må være et tall.");
                        }
                        else if (bokNr < 1 || bokNr > tilgjengeligeBøker.Count)
                        {
                            Console.WriteLine($"Ugyldig valg. Velg mellom 1 og {tilgjengeligeBøker.Count}.");
                        }
                        else
                        {
                            var valgtBok = tilgjengeligeBøker[bokNr - 1];
                            valgtBok.IsAvailable = false;
                            loans.Add(new Loan(lånerId, valgtBok.Title, DateTime.Now));
                            Console.WriteLine($"\n✓ {lånerStudent.Navn} har lånt '{valgtBok.Title}'.");
                        }
                    }
                }
            }


            break;

         case "7": // lever inn bøker
            
            Console.WriteLine("Levere inn bok:");
            Console.Write("StudentID: ");
            if (!int.TryParse(Console.ReadLine(), out int returStudentId))
            {
                Console.WriteLine("Ugyldig studentID.");
                break;
            }

            var aktiveLån = loans.Where(l => l.StudentID == returStudentId && l.IsActive).ToList();

            if (aktiveLån.Count == 0)
            {
                Console.WriteLine("Ingen aktive lån for denne studenten.");
                break;
            }

            Console.WriteLine("\nAktive lån:");
            for (int i = 0; i < aktiveLån.Count; i++)
            {
                var lån = aktiveLån[i];
                Console.WriteLine($"{i + 1}. {lån.BookTitle} (lånt: {lån.LoanDate:dd.MM.yyyy})");
            }

            Console.Write("\nVelg bok nummer å levere inn: ");
            if (!int.TryParse(Console.ReadLine(), out int lånNr) || lånNr < 1 || lånNr > aktiveLån.Count)
            {
                Console.WriteLine("Ugyldig valg.");
                break;
            }

            var returLån = aktiveLån[lånNr - 1];
            returLån.IsActive = false;
            returLån.ReturnDate = DateTime.Now;

            var returBok = books.Find(b => b.Title == returLån.BookTitle);
            if (returBok != null)
            {
                returBok.IsAvailable = true;
            }

            Console.WriteLine($"Bok '{returLån.BookTitle}' er returnert.");
           
            break;

         case "8":// vise aktive og lån og historikk
           
            var aktive = loans.Where(l => l.IsActive).ToList();

            if (aktive.Count == 0)
            {
                Console.WriteLine("Ingen aktive lån.");
            }
            else
            {
                foreach (var lån in aktive)
                {
                    var student = students.Find(s => s.Id == lån.StudentID);
                    string studentNavn = student != null ? student.Navn : "Ukjent";
                    Console.WriteLine($"StudentID: {lån.StudentID} ({studentNavn}) - Bok: {lån.BookTitle} - Lånt: {lån.LoanDate:dd.MM.yyyy}");
                }
            }

            Console.WriteLine("\n=== HISTORIKK (Returnerte lån) ===");
            var historikk = loans.Where(l => !l.IsActive).ToList();

            if (historikk.Count == 0)
            {
                Console.WriteLine("Ingen historikk.");
            }
            else
            {
                foreach (var lån in historikk)
                {
                    var student = students.Find(s => s.Id == lån.StudentID);
                    string studentNavn = student != null ? student.Navn : "Ukjent";
                    Console.WriteLine($"StudentID: {lån.StudentID} ({studentNavn}) - Bok: {lån.BookTitle} - Lånt: {lån.LoanDate:dd.MM.yyyy} - Returnert: {lån.ReturnDate:dd.MM.yyyy}");
                }
            }
            break;

        case "9": // registrere bøker
            Console.WriteLine("Registrere ny bok:");
            Console.Write("Tittel: ");
            var tittel = Console.ReadLine() ?? "";
            Console.Write("Forfatter: ");
            var forfatter = Console.ReadLine() ?? "";
            Console.Write("År: ");
            if (!int.TryParse(Console.ReadLine(), out int år)) år = 0;
            Console.Write("Pris: ");
            if (!double.TryParse(Console.ReadLine(), out double pris)) pris = 0.0;
            books.Add(new Book(tittel, forfatter, år, pris));
            Console.WriteLine($"Bok registrert: {tittel} av {forfatter}.");
            break;

        case "10": // vis all studenter lærere og utvekslingsstudenter

            // KRAV 11: Interface brukt som type - alle persontyper i én liste
            List<IPerson> allePersoner = new List<IPerson>();
            allePersoner.AddRange(students);
            allePersoner.AddRange(ansatte);
            allePersoner.AddRange(utstudenter);

            // LINQ: sorter alle personer etter navn
            var sortert = allePersoner.OrderBy(p => p.Navn).ToList();

            Console.WriteLine("\nAlle personer (sortert etter navn):");
            foreach (var person in sortert)
            {
                // KRAV 10: Polymorfisme - VisInfo() gir ulik output for Student, Ansatt, Utvekslingsstudent
                    Console.WriteLine($"  {person.VisInfo()}");
            }

            // KRAV 8: LINQ query-syntaks med GroupBy
            Console.WriteLine("\nStudenter gruppert etter kurs:");
            var gruppert = from s in students
                           group s by s.Kurs into g
                           orderby g.Key
                           select g;

            foreach (var gruppe in gruppert)
            {
                Console.WriteLine($"  Kurs: {(string.IsNullOrEmpty(gruppe.Key) ? "Ingen" : gruppe.Key)}");
                foreach (var s in gruppe)
                {
                    Console.WriteLine($"    {s.Id}: {s.Navn}");
                }
            }
            break;
        case "11": // registrer ny student
            Console.WriteLine("Registrere ny student:");
            Console.Write("StudentID: ");
            if (!int.TryParse(Console.ReadLine(), out int nyStudentId))
            {
                Console.WriteLine("Ugyldig studentID.");
                break;
            }
            Console.Write("Navn: ");
            string nyStudentNavn = Console.ReadLine() ?? "";
            Console.Write("Epost: ");
            string nyStudentEpost = Console.ReadLine() ?? "";
            Console.Write("Kurs (fagkode): ");
            string nyStudentKurs = Console.ReadLine() ?? "";

            students.Add(new Student(nyStudentId, nyStudentNavn, nyStudentEpost, nyStudentKurs));
            Console.WriteLine($"Student {nyStudentNavn} (ID: {nyStudentId}) er registrert.");
            break;

        case "12": // registrer ny ansatt
            Console.WriteLine("Registrere ny ansatt:");
            Console.Write("AnsattID: ");
            if (!int.TryParse(Console.ReadLine(), out int nyAnsattId))
            {
                Console.WriteLine("Ugyldig ansattID.");
                break;
            }
            Console.Write("Navn: ");
            string nyAnsattNavn = Console.ReadLine() ?? "";
            Console.Write("Epost: ");
            string nyAnsattEpost = Console.ReadLine() ?? "";
            Console.Write("Stilling: ");
            string nyAnsattStilling = Console.ReadLine() ?? "";
            Console.Write("Avdeling: ");
            string nyAnsattAvdeling = Console.ReadLine() ?? "";

            ansatte.Add(new Ansatt(nyAnsattId, nyAnsattNavn, nyAnsattEpost, nyAnsattStilling, nyAnsattAvdeling));
            Console.WriteLine($"Ansatt {nyAnsattNavn} (ID: {nyAnsattId}) er registrert.");
            break;

        case "13": // registrer ny utvekslingsstudent
            Console.WriteLine("Registrere ny utvekslingsstudent:");
            Console.Write("Navn: ");
            string nyutStudentNavn = Console.ReadLine() ?? "";
            Console.Write("Epost: ");
            string nyutStudentEpost = Console.ReadLine() ?? "";
            Console.Write("Kurs (fagkode): ");
            string nyutStudentKurs = Console.ReadLine() ?? "";
            Console.Write("Hjem universitet: ");
            string hjemUniversitet = Console.ReadLine() ?? "";
            Console.Write("Land: ");
            string land = Console.ReadLine() ?? "";
            Console.Write("Periode (f.eks. August 2025 - Juni 2026): ");
            string periode = Console.ReadLine() ?? "";

            int newUtId = students.Count + utstudenter.Count + 1;
            utstudenter.Add(new Utvekslingsstudent(newUtId, nyutStudentNavn, nyutStudentEpost, nyutStudentKurs, hjemUniversitet, land, periode));
            Console.WriteLine($"Utvekslingsstudent navn: {nyutStudentNavn}fra {hjemUniversitet} er registrert.");
            break;

        case "14": // avslutt
            Console.WriteLine("Takk for at du brukte programmet nå lukker det seg ha en fin dag");
            return;
    }
}

