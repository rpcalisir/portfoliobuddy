using Microsoft.AspNetCore.Mvc;
using PortfolioBuddy.Application.Services.Abstraction;
using PortfolioBuddy.Web.ViewModels;

public class PortfolioController : Controller
{
    private readonly IInvestmentQueryService _queryService;
    public PortfolioController(IInvestmentQueryService queryService) => _queryService = queryService;

    public async Task<IActionResult> Index()
    {
        var investmentsDtos = await _queryService.GetAllInvestmentsAsync();

        var vm = new PortfolioIndexViewModel
        {
            Investments = investmentsDtos.Select(d => new InvestmentCardViewModel(d)).ToList()
        };

        return View(vm);
    }
}
