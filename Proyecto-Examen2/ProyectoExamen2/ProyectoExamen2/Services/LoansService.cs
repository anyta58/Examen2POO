using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Database;
using ProyectoExamen2.Database.Entities;
using ProyectoExamen2.Services.Interfaces;

namespace ProyectoExamen2.Services
{
    public class LoansService : ILoansService
    {
        private readonly ProyectoExamen2Context _context;
        private readonly IMapper _mapper;

        public LoansService(ProyectoExamen2Context context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<(string message, IEnumerable<AmortizationEntity> amortizationPlan)> CreateClientAndLoanAsync(ClientEntity client, LoanEntity loan)
        {
            // Agregar el cliente
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            // Agregar el préstamo
            loan.ClientId = client.Id;
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            // Asegúrate de que el préstamo tiene un ID válido
            if (loan.Id == Guid.Empty)
            {
                throw new Exception("El préstamo no tiene un ID válido.");
            }

            // Calcular el plan de amortización
            var amortizationPlan = CalculateAmortizationPlan(loan);

            // Asignar el ID del préstamo a cada amortización
            foreach (var amortization in amortizationPlan)
            {
                amortization.LoanId = loan.Id;
            }

            // Agregar las amortizaciones al contexto y guardar
            _context.Amortizations.AddRange(amortizationPlan);
            await _context.SaveChangesAsync();

            return ("Préstamo y plan de amortización creados con éxito.", amortizationPlan);
        }

        public async Task<ClientEntity> GetClientWithLoansAndAmortizationsAsync(Guid clientId)
        {
            return await _context.Clients
                .Include(c => c.Loans)
                    .ThenInclude(l => l.Amortizations)
                .FirstOrDefaultAsync(c => c.Id == clientId);
        }

        public Task<ClientEntity> GetClientWithLoansAndAmortizationsAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<AmortizationEntity> CalculateAmortizationPlan(LoanEntity loan)
        {
            var plan = new List<AmortizationEntity>();
            decimal saldoPrincipal = loan.LoanAmount;
            decimal tasaInteresDiaria = loan.InterestRate / 100 / 365;
            decimal seguroVida = loan.LoanAmount * 0.0015m; // 0.15% de seguro de vida

            for (int i = 1; i <= loan.Term; i++)
            {
                int dias = (i == 1) ? 31 : 30; // Ajusta los días según la tabla
                decimal interes = saldoPrincipal * tasaInteresDiaria * dias;
                decimal principal = loan.LoanAmount / loan.Term;
                decimal svsd = seguroVida / loan.Term; // Ajusta según sea necesario
                decimal cuotaSinSVSD = interes + principal;
                decimal cuotaConSVSD = cuotaSinSVSD + svsd;

                plan.Add(new AmortizationEntity
                {
                    InstallmentNumber = i,
                    PaymentDate = loan.FirstPaymentDate.AddMonths(i - 1),
                    Days = dias,
                    Interest = interes,
                    Principal = principal,
                    LevelPaymentWithoutSVSD = cuotaSinSVSD,
                    LevelPaymentWithSVSD = cuotaConSVSD,
                    PrincipalBalance = saldoPrincipal - principal
                });

                saldoPrincipal -= principal;
            }

            return plan;
        }


    }
}
