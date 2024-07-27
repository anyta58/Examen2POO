using System.ComponentModel.DataAnnotations;

namespace ProyectoExamen2.Dtos.Loans
{
    public class LoanCreateDto
    {
        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "El monto del préstamo es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto del préstamo debe ser mayor que cero.")]
        public decimal LoanAmount { get; set; }

        [Required(ErrorMessage = "La tasa de comisión es obligatoria.")]
        [Range(0, 100, ErrorMessage = "La tasa de comisión debe estar entre 0 y 100.")]
        public decimal CommissionRate { get; set; }

        [Required(ErrorMessage = "La tasa de interés es obligatoria.")]
        [Range(0, 100, ErrorMessage = "La tasa de interés debe estar entre 0 y 100.")]
        public decimal InterestRate { get; set; }

        [Required(ErrorMessage = "El plazo es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El plazo debe ser al menos de 1 mes.")]
        public int Term { get; set; }

        [Required(ErrorMessage = "La fecha de desembolso es obligatoria.")]
        public DateTime DisbursementDate { get; set; }

        [Required(ErrorMessage = "La fecha del primer pago es obligatoria.")]
        public DateTime FirstPaymentDate { get; set; }
    }
}
