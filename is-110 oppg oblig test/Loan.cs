using System;
using System.Collections.Generic;
using System.Text;

namespace is_110_oppg_oblig_test
{
    public class Loan
    {
        public int StudentID { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsActive { get; set; }

        public Loan(int studentID, string bookTitle, DateTime loanDate)
        {
            StudentID = studentID;
            BookTitle = bookTitle;
            LoanDate = loanDate;
            IsActive = true;
            ReturnDate = null;
        }
    }
}
