using LønTransportberegner.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrer transportstrategier som enkeltstående (singleton), da vi kun skal bruge én transportmetode ad gangen
builder.Services.AddSingleton<ITransportStrategy, CarTransport>();     // Standard transport
builder.Services.AddSingleton<ITransportStrategy, ElectricBike>();     // Elektrisk cykel transport
builder.Services.AddSingleton<ITransportStrategy, publicTransport>();  // Offentlig transport

// Registrer TransportContext
builder.Services.AddSingleton<TransportContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();
