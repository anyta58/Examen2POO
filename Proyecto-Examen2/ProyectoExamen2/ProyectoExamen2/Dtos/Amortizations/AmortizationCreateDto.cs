using System.ComponentModel.DataAnnotations;

namespace ProyectoExamen2.Dtos.Amortizations
{
    public class AmortizationCreateDto
    {
        [Required(ErrorMessage = "El ID del préstamo es obligatorio.")]
        public Guid LoanId { get; set; }

        [Required(ErrorMessage = "El número de cuota es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de cuota debe ser al menos 1.")]
        public int InstallmentNumber { get; set; }

        [Required(ErrorMessage = "La fecha de pago es obligatoria.")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "El número de días es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de días debe ser al menos 1.")]
        public int Days { get; set; }

        [Required(ErrorMessage = "El interés es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El interés debe ser mayor que cero.")]
        public decimal Interest { get; set; }

        [Required(ErrorMessage = "El principal es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El principal debe ser mayor que cero.")]
        public decimal Principal { get; set; }

        [Required(ErrorMessage = "El pago nivelado sin SVSD es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El pago nivelado sin SVSD debe ser mayor que cero.")]
        public decimal LevelPaymentWithoutSVSD { get; set; }

        [Required(ErrorMessage = "El pago nivelado con SVSD es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El pago nivelado con SVSD debe ser mayor que cero.")]
        public decimal LevelPaymentWithSVSD { get; set; }

        [Required(ErrorMessage = "El saldo del principal es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El saldo del principal debe ser mayor que cero.")]
        public decimal PrincipalBalance { get; set; }
    }
}
