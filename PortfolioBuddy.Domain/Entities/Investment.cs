using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioBuddy.Domain.Entities;

public class Investment
{
    // Identity: unique id for this entity
    public int Id { get; set; }

    // Business data
    public string Name { get; set; } = string.Empty;

    // When the investment record (category inside the portfolio) was created
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation property (one-to-many). This models history of values.
    public ICollection<InvestmentDetail> Details { get; set; } = new List<InvestmentDetail>();

    // Example business helper(Runtime helper): get latest detail quickly (not persisted)
    //public InvestmentDetail? LatestDetail =>
    //    Details.OrderByDescending(d => d.Date).FirstOrDefault();

    [NotMapped]
    public InvestmentDetail? LatestDetail { get; set; }

    public static Investment Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Investment name cannot be empty.", nameof(name));

        return new Investment
        {
            Name = name,
            CreatedAt = DateTime.UtcNow
        };
    }
}
