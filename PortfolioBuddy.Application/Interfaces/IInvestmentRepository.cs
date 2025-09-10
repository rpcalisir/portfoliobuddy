using PortfolioBuddy.Domain.Entities;
using System;

namespace PortfolioBuddy.Application.Interfaces;

public interface IInvestmentRepository
{
    Task<Investment> AddInvestmentAsync(Investment investment, CancellationToken ct = default);
    Task<InvestmentDetail> AddInvestmentDetailAsync(InvestmentDetail detail, CancellationToken ct = default);

    //Sometimes, to write, you must first load the entity into memory.
    Task<Investment?> GetInvestmentByIdAsync(int id, CancellationToken ct = default);
}
