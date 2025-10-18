using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oprim.Application;
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
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();

builder.Services.AddAuthorizationBuilder();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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