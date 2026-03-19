using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public abstract class Person : IPerson
    {
        public int Id { get; protected set; }
        public string Navn { get; set; }
        public string Epost { get; set; }

        protected Person(int id, string navn, string epost)
        {
            Id = id;
            Navn = navn;
            Epost = epost;
        }

        public virtual string VisInfo()
        {
            return $"{Id}: {Navn} ({Epost})";
        }
    }
}
