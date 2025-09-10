using Microsoft.EntityFrameworkCore;
using PortfolioBuddy.Application.Interfaces;
using PortfolioBuddy.Application.Services;
using PortfolioBuddy.Application.Services.Abstraction;
using PortfolioBuddy.Infrastructure.Persistence;
using PortfolioBuddy.Infrastructure.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// DI: register repository and service
builder.Services.AddScoped<IInvestmentRepository, InvestmentRepository>();
builder.Services.AddScoped<IInvestmentReadRepository, InvestmentReadRepository>();

builder.Services.AddScoped<IInvestmentService, InvestmentService>();
builder.Services.AddScoped<IInvestmentQueryService, InvestmentQueryService>();


var app = builder.Build();

// Auto-apply pending migrations at startup (development convenience)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Portfolio}/{action=Index}/{id?}"
);

app.Run();
