using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Database;
using ProyectoExamen2.Database.Entities;
using ProyectoExamen2.Services;

namespace ProyectoExamen2.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly LoansService _loansService;
        private readonly ProyectoExamen2Context _context;

        public LoansController(LoansService loansService, ProyectoExamen2Context context)
        {
            this._loansService = loansService;
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClientAndLoan([FromBody] CreateClientAndLoanRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = new ClientEntity
            {
                Name = request.Name,
                IdentityNumber = request.IdentityNumber,
            };

            var loan = new LoanEntity
            {
                LoanAmount = request.LoanAmount,
                CommissionRate = request.CommissionRate,
                InterestRate = request.InterestRate,
                Term = request.Term,
                DisbursementDate = request.DisbursementDate,
                FirstPaymentDate = request.FirstPaymentDate
            };

            var (message, amortizationPlan) = await _loansService.CreateClientAndLoanAsync(client, loan);

            return Ok(new
            {
                message,
                amortizationPlan
            });
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClientAndAmortizations(Guid clientId)
        {
            // Implementar lógica para obtener datos del cliente y amortizaciones
            var client = await _context.Clients
                .Include(c => c.Loans)
                    .ThenInclude(l => l.Amortizations)
                .FirstOrDefaultAsync(c => c.Id == clientId);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
    }

    public class CreateClientAndLoanRequest
    {
        public string Name { get; set; }
        public int IdentityNumber { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal InterestRate { get; set; }
        public int Term { get; set; }
        public DateTime DisbursementDate { get; set; }
        public DateTime FirstPaymentDate { get; set; }
    }

}
