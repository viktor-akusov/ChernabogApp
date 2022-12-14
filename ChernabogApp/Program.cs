using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChernabogApp.Data;
using Microsoft.AspNetCore.Identity;
using ChernabogApp.Areas.Identity.Data;
using ChernabogApp.Populators;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ChernabogAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ChernabogAppContext") ?? throw new InvalidOperationException("Connection string 'ChernabogAppContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ChernabogAppContext>();
var app = builder.Build();

using(var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetService<ChernabogAppContext>();

    var classPopulator = new CharClassPopulate(context, context.CharClass);
    var racePopulator = new RacePopulate(context, context.Race);

    classPopulator.Seed().Wait();
    racePopulator.Seed().Wait();
}

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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
