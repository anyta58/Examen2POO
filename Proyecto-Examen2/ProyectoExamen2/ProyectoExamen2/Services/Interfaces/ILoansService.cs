using ProyectoExamen2.Database.Entities;

namespace ProyectoExamen2.Services.Interfaces
{
    public interface ILoansService
    {
        Task<(string message, IEnumerable<AmortizationEntity> amortizationPlan)> CreateClientAndLoanAsync(ClientEntity client, LoanEntity loan);

        Task<ClientEntity> GetClientWithLoansAndAmortizationsAsync(int clientId);
    }
}
