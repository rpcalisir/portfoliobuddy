using Microsoft.AspNetCore.Mvc;
using PortfolioBuddy.Application.DTOs;
using PortfolioBuddy.Application.Services.Abstraction;
using PortfolioBuddy.Web.ViewModels;

namespace PortfolioBuddy.Web.Controllers;

public class InvestmentsController : Controller
{
    private readonly IInvestmentService _investmentService;
    private readonly IInvestmentQueryService _investmentQueryService;

    public InvestmentsController(IInvestmentService investmentService, IInvestmentQueryService investmentQueryService)
    {
        _investmentService = investmentService;
        _investmentQueryService = investmentQueryService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Name required.");

        //InvestmentDto investmentDto = await _svc.CreateInvestmentAsync(name.Trim());

        // 1. Command: create investment, get ID
        int investmentId = await _investmentService.CreateInvestmentAsync(name.Trim());

        // Always go through QueryService after command
        // 2. Query: reload DTO
        InvestmentDto? investmentDto = await _investmentQueryService.GetInvestmentByIdAsync(investmentId);

        if (investmentDto == null) return BadRequest("Investment not found.");

        // 3. Map to ViewModel
        InvestmentCardViewModel investmentCardViewModel = new InvestmentCardViewModel(investmentDto);

        // 4. Return partial view HTML
        //return PartialView("~/Views/Shared/_InvestmentCard.cshtml", investmentCardViewModel);
        return PartialView("_InvestmentCard", investmentCardViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddDetail([FromForm] int investmentId,
                                               [FromForm] decimal amount,
                                               [FromForm] string unit,
                                               [FromForm] decimal valueInTl)
    {
        //await _svc.AddInvestmentDetailAsync(investmentId, amount, unit, valueInTl);
        //return Ok();

        // 1. Command: add detail, get detail ID
        int investmentDetailId = await _investmentService.AddInvestmentDetailAsync(investmentId, amount, unit, valueInTl);

        // 2. Re-query latest DTO from read repo
        InvestmentDto? investmentDto = await _investmentQueryService.GetInvestmentByIdAsync(investmentId);

        if (investmentDto == null) return BadRequest("Investment not found.");

        // 3. Map to ViewModel
        InvestmentCardViewModel investmentCardViewModel = new InvestmentCardViewModel(investmentDto);

        // 4. Return updated card as HTML
        return PartialView("_InvestmentCard", investmentCardViewModel);

        //return Json(investmentDto.LatestDetail); // returns JSON
    }

}
