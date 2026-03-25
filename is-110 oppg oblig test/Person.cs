using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    // KRAV 11: Abstrakt klasse - kan ikke instansieres direkte, kun arves
    public abstract class Person : IPerson
    {
        // KRAV 2: Auto-implementerte egenskaper
        // KRAV 3: Tilgangsmodifikator - protected set: kun subklasser kan endre
        public int Id { get; protected set; }
        public string Navn { get; protected set; }
        public string Epost { get; protected set; }

        // KRAV 3: protected konstruktør - kan bare kalles av subklasser
        protected Person(int id, string navn, string epost)
        {
            Id = id;
            Navn = navn;
            Epost = epost;
        }

        // KRAV 10: Polymorfisme - abstrakt metode som MÅ overrides i subklasser
        public abstract string VisInfo();
    }
}
