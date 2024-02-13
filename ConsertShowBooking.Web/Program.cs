using ConcertShowBooking_Repositories;
using ConcertShowBooking_Repositories.Implementations;
using ConcertShowBooking_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Identity;
using ConcertShowBooking_Entities;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ConsertShowBookingWebContextConnection") ?? throw new InvalidOperationException("Connection string 'ConsertShowBookingWebContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
var config = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("cons"),b => b.MigrationsAssembly("ConsertShowBooking.Web")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
    .AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

builder.Services.AddScoped<IVenueRepo, VenueRepo>();
builder.Services.AddScoped<IArtistRepo,ArtistRepo>();
builder.Services.AddScoped<IShowRepo,ShowRepo>();
builder.Services.AddScoped<IUtilityRepo,UtilityRepo>();
builder.Services.AddScoped<ITicketRepo,TicketRepo>();
builder.Services.AddScoped<IDbInitial,DbInitial>();
builder.Services.AddScoped<IEmailSender,EmailSender>();
builder.Services.AddScoped<IBookingRepo,BookingRepo>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

DataSeading();

void DataSeading()
{
    using(var scope=app.Services.CreateScope())
    {
        var dbRepo = scope.ServiceProvider.GetRequiredService<IDbInitial>();
        dbRepo.Seed();
    }
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
