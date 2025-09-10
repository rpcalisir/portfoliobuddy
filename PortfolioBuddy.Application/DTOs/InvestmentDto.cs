using PortfolioBuddy.Application.DTOs;
using System.Diagnostics.Metrics;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortfolioBuddy.Application.DTOs;

public class InvestmentDto
{
    //InvestmentDto.Id is required → so UI can identify which card belongs to which investment(data-inv-id= "@Model.Investment.Id").
    //InvestmentDetailDto.Id is missing because currently you never reference details individually in the UI.
    //    Example:
    //When you add detail, you don’t need detail.Id in JavaScript.
    //You only show Amount, Unit, ValueInTL, Date.
    //👉 If in the future you need to edit or delete details, then you’ll absolutely add Id to InvestmentDetailDto.
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public InvestmentDetailDto? LatestDetail { get; set; }
}
