using WildRealms.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;

var builder = WebApplication.CreateBuilder(args);
// Ajoute les services nécessaires aux sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Durée de session
    options.Cookie.HttpOnly = true; // Protection contre l'accès JS
    options.Cookie.IsEssential = true; // Indique que le cookie est essentiel
});

builder.Services.AddHttpContextAccessor(); // Ajoute l'accès à HttpContext (facultatif)
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
app.UseSession();
// Register DbContext with the connection string (adjust for your DB provider)


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
