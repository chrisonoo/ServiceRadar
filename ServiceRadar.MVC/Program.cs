using ServiceRadar.Application.Common.Extensions;
using ServiceRadar.Infrastructure.Extensions;
using ServiceRadar.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Add all services from the Infrastructure project
builder.Services.AddInfrastructure(builder.Configuration);
// Add all services from the Application project
builder.Services.AddApplication();

// Collaborate with UseDeveloperExceptionPage() and catches EF Core errors
// https://github.com/aspnet/Announcements/issues/432
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Add this functionality if developer mode is enabled.
if(app.Environment.IsDevelopment())
{
    // Collaborate with AddDatabaseDeveloperPageExceptionFilter() and catches EF Core errors
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    // Run the seed initializer if developer mode is not enabled
    using(var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        await ServiceRadarSeeder.SeedSampleDataAsync(services);
    }
}

// Configure the HTTP request pipeline if developer mode is not enabled.
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

app.MapRazorPages();

app.Run();
