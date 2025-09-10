using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace PortfolioBuddy.Domain.Entities;

public class InvestmentDetail
{
    public int Id { get; set; }

    // Foreign key (links to Investment.Id)
    public int InvestmentId { get; set; }

    // Domain data
    public decimal Amount { get; set; }
    public string Unit { get; set; } = string.Empty; // "GR", "EUR", etc.
    public decimal ValueInTL { get; set; }           // converted value in TL
    public DateTime Date { get; set; } = DateTime.UtcNow;

    // Back-navigation: optional reference to parent Investment
    public Investment? Investment { get; set; }

    // Factory method enforces rules.
    //👉 This way, business rules live inside Domain Entity, not in Application Service.
    public static InvestmentDetail Create(int investmentId, decimal amount, string unit, decimal valueInTl)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Amount must be positive.");

        return new InvestmentDetail
        {
            InvestmentId = investmentId,
            Amount = amount,
            Unit = unit,
            ValueInTL = valueInTl,
            Date = DateTime.UtcNow
        };
    }
}
