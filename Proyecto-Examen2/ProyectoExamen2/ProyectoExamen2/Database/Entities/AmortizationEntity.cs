using Azure.Core.Pipeline;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamen2.Database.Entities
{
    [Table("amortizations", Schema = "dbo")]
    public class AmortizationEntity : BaseEntity 
    {
        [Column("client_id")]
        public Guid LoanId { get; set; }
        [ForeignKey(nameof(LoanId))]
        public virtual LoanEntity Loan { get; set; }

        [Column("installment_number")]
        public int InstallmentNumber { get; set; }

        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }

        [Column("days")]
        public int Days { get; set; }

        [Column("interest")]
        public decimal Interest { get; set; }

        [Column("principal")]
        public decimal Principal { get; set; }

        [Column("level_payment_without_SVSD")]
        public decimal LevelPaymentWithoutSVSD { get; set; }

        [Column("level_payment_with_SVSD")]
        public decimal LevelPaymentWithSVSD { get; set; }

        [Column("principal_balance")]
        public decimal PrincipalBalance { get; set; }
    }
}
