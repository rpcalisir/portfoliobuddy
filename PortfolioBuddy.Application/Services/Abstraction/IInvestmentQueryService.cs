using PortfolioBuddy.Application.DTOs;

namespace PortfolioBuddy.Application.Services.Abstraction;

public interface IInvestmentQueryService
{
    Task<List<InvestmentDto>> GetAllInvestmentsAsync(CancellationToken ct = default);
    Task<InvestmentDto?> GetInvestmentByIdAsync(int id, CancellationToken ct = default);
}
