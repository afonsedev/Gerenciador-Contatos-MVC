using ControleContatos.Data;
using ControleContatos.Repositório;
using ControleContatos.Controllers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//IServiceCollection services = builder.Services;
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer
("Data Source=localhost;Initial Catalog= CRUD_MVC; Integrated Security=True;Trust Server Certificate=True"));

builder.Services.AddScoped<IContatoRepositório, ContatoRepositório>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


