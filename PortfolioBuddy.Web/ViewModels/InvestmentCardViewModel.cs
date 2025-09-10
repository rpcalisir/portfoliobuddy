using PortfolioBuddy.Application.DTOs;

namespace PortfolioBuddy.Web.ViewModels;

public class InvestmentCardViewModel
{
    public InvestmentDto Investment { get; }
    public string LatestValueText { get; }
    public string LatestDateText { get; }

    public InvestmentCardViewModel(InvestmentDto dto)
    {
        Investment = dto;
        if (dto.LatestDetail == null)
        {
            LatestValueText = "No data";
            LatestDateText = "";
        }
        else
        {
            LatestValueText = $"{dto.LatestDetail.Amount} {dto.LatestDetail.Unit} = {dto.LatestDetail.ValueInTL:N0} TL";
            LatestDateText = dto.LatestDetail.Date.ToString("dd.MM.yyyy");
        }
    }
}
