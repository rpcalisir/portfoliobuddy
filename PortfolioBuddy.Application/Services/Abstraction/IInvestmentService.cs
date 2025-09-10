using PortfolioBuddy.Application.DTOs;

namespace PortfolioBuddy.Application.Services.Abstraction;

public interface IInvestmentService
{
    Task<int> CreateInvestmentAsync(string name, CancellationToken ct = default);
    Task<int> AddInvestmentDetailAsync(int investmentId, decimal amount, string unit, decimal valueInTl, CancellationToken ct = default);
}
