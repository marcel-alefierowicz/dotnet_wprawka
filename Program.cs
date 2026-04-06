using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("WprawkaDB");
builder.Services.AddDbContext<WprawkaDBContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "klienci",
    pattern: "klienci/{action=Index}/{id?}",
    defaults: new { controller = "Klient" });

app.MapControllerRoute(
    name: "denaci",
    pattern: "denaci/{action=Index}/{id?}",
    defaults: new { controller = "Denat" });

app.MapControllerRoute(
    name: "placowki",
    pattern: "placowki/{action=Index}/{id?}",
    defaults: new { controller = "Placowka" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
