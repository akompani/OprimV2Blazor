using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using MudBlazor.Services;
using Oprim.Application;
using Oprim.Application.Identities;
using Oprim.Domain.Database;
using Oprim.Domain.Entities.Identity;
using Oprim.Infrastructure;
using Oprim.Ui;
using Oprim.Ui.Components;

var builder = WebApplication.CreateBuilder(args);

// -------------------------
// 🔹 Register Services
// -------------------------
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddUiServices();

// ✅ Identity و Authentication
builder.Services.AddIdentity<User, Role>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// افزودن اتوماتیک همه Policyها
builder.Services.AddPermissionPolicies();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddMudServices();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/AccessDenied";
});

// -------------------------
// 🔹 Build App
// -------------------------
var app = builder.Build();
// -------------------------
// 🔹 Middleware Pipeline
// -------------------------
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Auth middlewares
app.UseAuthentication();
app.UseAuthorization();

// ✅ باید بعد از Auth و قبل از MapRazorComponents بیاد
app.UseAntiforgery();

// ✅ Razor components mapping
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// ✅ Map static assets (Blazor 9 feature)
app.MapStaticAssets();

app.Run();