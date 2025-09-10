using Microsoft.EntityFrameworkCore;
using PortfolioBuddy.Application.Interfaces;
using PortfolioBuddy.Domain.Entities;
using PortfolioBuddy.Infrastructure.Persistence;

namespace PortfolioBuddy.Infrastructure.Repositories;

//Write repositories return Entities → commands.
public class InvestmentRepository : IInvestmentRepository
{
    private readonly AppDbContext _ctx;
    public InvestmentRepository(AppDbContext ctx) => _ctx = ctx;
    public async Task<Investment> AddInvestmentAsync(Investment investment, CancellationToken ct = default)
    {
        _ctx.Investments.Add(investment);
        await _ctx.SaveChangesAsync(ct);
        return investment;
    }

    public async Task<InvestmentDetail> AddInvestmentDetailAsync(InvestmentDetail detail, CancellationToken ct = default)
    {
        _ctx.InvestmentDetails.Add(detail);
        await _ctx.SaveChangesAsync(ct);
        return detail;
    }

    public Task<Investment?> GetInvestmentByIdAsync(int id, CancellationToken ct = default) =>
        _ctx.Investments
            .Include(i => i.Details) // entities needed for domain logic
            .FirstOrDefaultAsync(i => i.Id == id, ct);
}
