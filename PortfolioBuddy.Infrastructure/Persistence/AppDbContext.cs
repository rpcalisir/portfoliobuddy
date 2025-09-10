using Microsoft.EntityFrameworkCore;
using PortfolioBuddy.Domain.Entities;

namespace PortfolioBuddy.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Investment> Investments => Set<Investment>();
    public DbSet<InvestmentDetail> InvestmentDetails => Set<InvestmentDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Investment>(b =>
        {
            b.ToTable("Investments");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(200).IsRequired();
            b.Property(x => x.CreatedAt).IsRequired();
            b.HasMany(x => x.Details)
             .WithOne(d => d.Investment)
             .HasForeignKey(d => d.InvestmentId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<InvestmentDetail>(b =>
        {
            b.ToTable("InvestmentDetails");
            b.HasKey(x => x.Id);
            b.Property(x => x.Unit).HasMaxLength(20);
            b.Property(x => x.Amount).HasPrecision(18, 4);
            b.Property(x => x.ValueInTL).HasPrecision(18, 2);
            b.Property(x => x.Date).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}
