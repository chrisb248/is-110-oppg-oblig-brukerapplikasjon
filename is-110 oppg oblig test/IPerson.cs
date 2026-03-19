using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public interface IPerson
    {
        int Id { get; }
        string Navn { get; }
        string Epost { get; }
        string VisInfo();
    }
}
