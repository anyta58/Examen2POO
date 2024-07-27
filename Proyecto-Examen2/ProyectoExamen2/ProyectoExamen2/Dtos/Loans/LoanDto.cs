using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoExamen2.Database.Entities;

namespace ProyectoExamen2.Dtos.Loans
{
    public class LoanDto
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public decimal LoanAmount { get; set; }

        public decimal CommissionRate { get; set; }

        public decimal InterestRate { get; set; }

        public int Term { get; set; }

        public DateTime DisbursementDate { get; set; }

        public DateTime FirstPaymentDate { get; set; }

    }
}
