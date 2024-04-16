using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingMachine.BackgroundServices;
using VendingMachine.DBContext;
using VendingMachine.Repositories;
using VendingMachine.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();
builder.Services.AddScoped<ICoinRepository, CoinRepository>();
//builder.Services.AddHostedService<ConsolePrintTest>();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
});

var app = builder.Build();
/*app.Use(async (context, next) =>
{
    context.RequestServices.GetRequiredService<ApplicationContext>();
    await next.Invoke();
});*/

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
