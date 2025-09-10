using PortfolioBuddy.Application.DTOs;
using PortfolioBuddy.Application.Interfaces;
using PortfolioBuddy.Application.Services.Abstraction;

namespace PortfolioBuddy.Application.Services
{
    public class InvestmentQueryService : IInvestmentQueryService
    {
        private readonly IInvestmentReadRepository _repo;
        public InvestmentQueryService(IInvestmentReadRepository repo) => _repo = repo;

        public Task<List<InvestmentDto>> GetAllInvestmentsAsync(CancellationToken ct = default) =>
            _repo.GetAllInvestmentsAsync(ct);

        public Task<InvestmentDto?> GetInvestmentByIdAsync(int id, CancellationToken ct = default) =>
            _repo.GetInvestmentByIdAsync(id, ct);
    }
}
