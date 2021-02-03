using System;

namespace My.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }       
    }
}
