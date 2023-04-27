using Editorial.UI.Application.Contracts;
using Microsoft.AspNetCore.Identity;
using Taller.Application;
using Taller.Application.Context;
using Taller.Domain.ConfigurationModels;
using Taller.Domain.EntityModels.Identity;
using Taller.Identity;
using Taller.Persistence;
using Taller.Persistence.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.Configure<SmtpConfiguration>
    (builder.Configuration.GetSection("SmtpConfiguration"));

builder.Services.AddIdentityCore<Usuario>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<Usuario>>(TokenOptions.DefaultProvider);

builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
