using Azure.Core.Pipeline;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamen2.Database.Entities
{
    [Table("loans", Schema = "dbo")]
    public class LoanEntity : BaseEntity
    {
        [Column("client_id")]
        public Guid ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public virtual ClientEntity Client { get; set; }

        [Column("loan_amount")]
        public decimal LoanAmount { get; set; }

        [Column("commission_rate")]
        public decimal CommissionRate { get; set; }

        [Column("interes_rate")]
        public decimal InterestRate { get; set; }

        [Column("term")]
        public int Term { get; set; }

        [Column("disbursement_date")]
        public DateTime DisbursementDate { get; set; }

        [Column("first_payment_date")]
        public DateTime FirstPaymentDate { get; set; }

        [JsonIgnore]
        public ICollection<AmortizationEntity> Amortizations { get; set; }

    }
}
