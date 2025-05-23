using LønTransportberegner.Models.Domæne;
using LønTransportberegner.Repositories;
using LønTransportberegner.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ConnectDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services.AddSingleton<TransportContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Logging.ClearProviders(); 
builder.Logging.AddConsole();      
builder.Logging.SetMinimumLevel(LogLevel.Information); 

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ConnectDbContext>();
    db.Database.Migrate(); // <-- denne linje
}

app.Run();
