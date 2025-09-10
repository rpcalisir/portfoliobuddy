namespace PortfolioBuddy.Application.DTOs;

public class InvestmentDetailDto
{
    public decimal Amount { get; set; }
    public string Unit { get; set; } = string.Empty;
    public decimal ValueInTL { get; set; }
    public DateTime Date { get; set; }
}
