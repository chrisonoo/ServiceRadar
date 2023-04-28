using ServiceRadar.Application.Extensions;
using ServiceRadar.Infrastructure.Extensions;
using ServiceRadar.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add all services from the Infrastructure project
builder.Services.AddInfrastructure(builder.Configuration);
// Add all services from the Application project
builder.Services.AddApplication();

var app = builder.Build();

// run the seed initializer
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    ServiceRadarSeeder.Initialize(services);
}

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
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
