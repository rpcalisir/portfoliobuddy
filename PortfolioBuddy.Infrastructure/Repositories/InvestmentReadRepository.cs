using Microsoft.EntityFrameworkCore;
using PortfolioBuddy.Application.DTOs;
using PortfolioBuddy.Application.Interfaces;
using PortfolioBuddy.Infrastructure.Persistence;

namespace PortfolioBuddy.Infrastructure.Repositories
{
    //Read repositories return DTOs → queries.
    public class InvestmentReadRepository : IInvestmentReadRepository
    {
        private readonly AppDbContext _ctx;
        public InvestmentReadRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<List<InvestmentDto>> GetAllInvestmentsAsync(CancellationToken ct = default)
        {
            return await _ctx.Investments
                .Select(i => new InvestmentDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    LatestDetail = i.Details
                        .OrderByDescending(d => d.Date)
                        .Select(d => new InvestmentDetailDto
                        {
                            Amount = d.Amount,
                            Unit = d.Unit,
                            ValueInTL = d.ValueInTL,
                            Date = d.Date
                        })
                        .FirstOrDefault()
                })
                .AsNoTracking() // no ChangeTracker → read-only
                .ToListAsync(ct);
        }

        public Task<InvestmentDto?> GetInvestmentByIdAsync(int id, CancellationToken ct = default) =>
            _ctx.Investments
                .Where(i => i.Id == id)
                .Select(i => new InvestmentDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    LatestDetail = i.Details
                        .OrderByDescending(d => d.Date)
                        .Select(d => new InvestmentDetailDto
                        {
                            Amount = d.Amount,
                            Unit = d.Unit,
                            ValueInTL = d.ValueInTL,
                            Date = d.Date
                        })
                        .FirstOrDefault()
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(ct);
    }
}
