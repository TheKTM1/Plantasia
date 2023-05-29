using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plantasia.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("MemoryDb"));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



 var user = new UserModel 
{
UserName = "user@user.user",
Email = "user@user.user",
ID = Guid.NewGuid().ToString(),
FirstName = "Norbert",
LastName = "Gierczak",
EmailConfirmed = true
};

var user1 = new UserModel 
{
UserName = "user@user.user",
Email = "user@user.user",
ID = Guid.NewGuid().ToString(),
FirstName = "Obelix",
LastName = "PorkEnjoyer",
EmailConfirmed = true
};

 var user2 = new UserModel 
{
UserName = "user@user.user",
Email = "user@user.user",
ID = Guid.NewGuid().ToString(),
FirstName = "Asterix",
LastName = "Blondas",
EmailConfirmed = true
};


 
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
