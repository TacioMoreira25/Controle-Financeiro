using FinanceControl.Models;
using FinanceControl.DAL; // Adicione o namespace onde IFinancasDAL e FinancasDAL est�o definidos
using Microsoft.EntityFrameworkCore;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Ignorar erros de certificado SSL globalmente
System.Net.ServicePointManager.ServerCertificateValidationCallback +=
    (sender, cert, chain, sslPolicyErrors) => true;

// Adiciona o AppDbContext ao cont�iner de servi�os com a configura��o da string de conex�o
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MinhaConnectionString")));

// Registra a interface e sua implementa��o com escopo de vida espec�fico
builder.Services.AddScoped<IFinancasDAL, FinancasDAL>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
