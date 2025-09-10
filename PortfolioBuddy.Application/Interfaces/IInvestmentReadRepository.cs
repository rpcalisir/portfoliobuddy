using PortfolioBuddy.Application.DTOs;

namespace PortfolioBuddy.Application.Interfaces;

// You can reduce coupling by using interfaces in Application.
// Example:
// IInvestmentReadRepository is defined in Application(knows about DTOs).
// InvestmentReadRepository in Infrastructure implements it.
// That way, Application only depends on abstraction, not EF Core.
// This is exactly what you already started doing ✅
// So you keep efficiency (DTO projection in DB) without breaking layering.
public interface IInvestmentReadRepository
{
    Task<List<InvestmentDto>> GetAllInvestmentsAsync(CancellationToken ct = default);
    Task<InvestmentDto?> GetInvestmentByIdAsync(int id, CancellationToken ct = default);
}
