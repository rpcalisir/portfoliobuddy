using PortfolioBuddy.Application.Interfaces;
using PortfolioBuddy.Application.Services.Abstraction;
using PortfolioBuddy.Domain.Entities;

namespace PortfolioBuddy.Application.Services;

public class InvestmentService : IInvestmentService
{
    private readonly IInvestmentRepository _investmentRepository;

    public InvestmentService(IInvestmentRepository investmentRepository)
    {
        _investmentRepository = investmentRepository;
    }

    //private readonly IInvestmentQueryService _investmentQueryService;

    //public InvestmentService(IInvestmentRepository investmentRepository, IInvestmentQueryService investmentQueryService)
    //{
    //    _investmentRepository = investmentRepository;
    //    _investmentQueryService = investmentQueryService;
    //}

    public async Task<int> CreateInvestmentAsync(string name, CancellationToken ct = default)
    {
        var investmentInstance = Investment.Create(name);

        var createdInvestment = await _investmentRepository.AddInvestmentAsync(investmentInstance, ct);
        return createdInvestment.Id;
        //return new InvestmentDto { Id = created.Id, Name = created.Name };
    }

    public async Task<int> AddInvestmentDetailAsync(int investmentId, decimal amount, string unit, decimal valueInTl, CancellationToken ct = default)
    {
        // Use domain factory or entity methods for business rules
        InvestmentDetail investmentDetailInstance = InvestmentDetail.Create(investmentId, amount, unit, valueInTl);
        InvestmentDetail createdInvestmentDetail = await _investmentRepository.AddInvestmentDetailAsync(investmentDetailInstance, ct);

        // Load updated Investment with latest detail
        //InvestmentDto investmentDto = await _investmentQueryService.GetByIdAsync(investmentId, ct);

        //return new InvestmentDto
        //{
        //    Id = investmentDto.Id,
        //    Name = investmentDto.Name,
        //    LatestDetail = new InvestmentDetailDto
        //    {
        //        Amount = createdInvestmentDetail.Amount,
        //        Unit = createdInvestmentDetail.Unit,
        //        ValueInTL = createdInvestmentDetail.ValueInTL,
        //        Date = createdInvestmentDetail.Date
        //    }
        //};

        return createdInvestmentDetail.Id;
    }

}
