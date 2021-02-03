using System;
using System.Collections.Generic;

namespace My.Data.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public int Status { get; set; }
        public bool IsClosed { get; set; }

        public IEnumerable<Payment> Payments { get; set; }
        
    }
}
