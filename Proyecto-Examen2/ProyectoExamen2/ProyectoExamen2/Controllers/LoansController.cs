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
                amortizationPlan = amortizationPlan.Select(a => new
                {
                    a.InstallmentNumber,
                    a.PaymentDate,
                    a.Days,
                    a.Interest,
                    a.Principal,
                    a.LevelPaymentWithoutSVSD,
                    a.LevelPaymentWithSVSD,
                    a.PrincipalBalance
                })
            });
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClientAndAmortizations(Guid clientId)
        {
            // Implementar lógica para obtener datos del cliente y amortizaciones
            var client = await _loansService
                .GetClientWithLoansAndAmortizationsAsync(clientId);

            if (client == null)
            {
                return NotFound();
            }

            var response = new
            {
                clientId = client.Id,
                name = client.Name,
                identityNumber = client.IdentityNumber,
                loanAmount = client.Loans.FirstOrDefault()?.LoanAmount ?? 0,
                amortizationPlan = client.Loans.SelectMany(l => l.Amortizations).Select(a => new
                {
                    a.InstallmentNumber,
                    a.PaymentDate,
                    a.Days,
                    a.Interest,
                    a.Principal,
                    a.LevelPaymentWithoutSVSD,
                    a.LevelPaymentWithSVSD,
                    a.PrincipalBalance
                })
            };

            return Ok(response);
        }

        //Inge agregre este endpoint por que se me habian creado varios usuarios que no ocupaba en la base de datos 
        [HttpDelete("client/{clientId}")]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            var result = await _loansService.DeleteClientByIdAsync(clientId);
            if (!result)
            {
                return NotFound(new { message = "Client not found." });
            }

            return Ok(new { message = "Cliente y préstamos asociados eliminados correctamente." });
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
