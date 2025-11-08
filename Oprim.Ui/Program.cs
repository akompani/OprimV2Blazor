using System.Globalization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using MudBlazor.Services;
using Oprim.Application;
using Oprim.Infrastructure;
using Oprim.Ui;
using Oprim.Ui.Components;
using Oprim.Ui.Resources.Models;

var builder = WebApplication.CreateBuilder(args);

// -------------------------
// 🔹 Register Services
// -------------------------
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddUiServices();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
// 🔹 تنظیم Culture پیش‌فرض
builder.Services.AddSingleton<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();
builder.Services.AddScoped(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));

// ثبت AppResource به عنوان Scoped (یا Singleton)
builder.Services.AddScoped<AppResource>();
// ✅ Identity و Authentication
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();

builder.Services.AddAuthorizationBuilder();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddMudServices();
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// -------------------------
// 🔹 Build App
// -------------------------
var app = builder.Build();

var supportedCultures = new[] { "en", "fa" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
    {
        var segments = context.Request.Path.Value.Split('/');
        var culture = segments.Length > 1 ? segments[1] : "en";
        return await Task.FromResult(new ProviderCultureResult(culture));
    }))
    .AddSupportedCultures("en", "fa")
    .AddSupportedUICultures("en", "fa"));

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