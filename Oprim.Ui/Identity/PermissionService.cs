using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Oprim.Application.Interfaces;
using Oprim.Domain.Entities.Identity;

namespace Oprim.Ui.Identity;

public class PermissionService:IPermissionService
{
    private readonly NavigationManager _navigationManager;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly AuthenticationStateProvider _authProvider;

    public PermissionService(
        NavigationManager navigationManager,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        AuthenticationStateProvider authProvider)
    {
        _navigationManager = navigationManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _authProvider = authProvider;
    }

    public async Task<bool> HasPermissionForPage(string path)
    {
        var authState = await _authProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        if (!user.Identity?.IsAuthenticated ?? true)
            return false;

        var appUser = await _userManager.GetUserAsync(user);
        if (appUser == null)
            return false;

        var roles = await _userManager.GetRolesAsync(appUser);
        var neededPermission = GetPermissionFromPath(path);

        foreach (var roleName in roles)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) continue;
            var claims = await _roleManager.GetClaimsAsync(role);
            if (claims.Any(c => c.Type == "Permission" && c.Value == neededPermission))
                return true;
        }

        return false;
    }

    private string GetPermissionFromPath(string path)
    {
        // /products/create → Products.Create
        var segments = path.Trim('/').Split('/', StringSplitOptions.RemoveEmptyEntries);

        if (segments.Length == 0) return string.Empty;

        string area = segments[0].ToLower();
        string action = segments.Length > 1 ? segments[1].ToLower() : "view";

        return $"{Cap(area)}.{Cap(action)}";
    }

    private string Cap(string input) =>
        string.IsNullOrWhiteSpace(input) ? input : char.ToUpper(input[0]) + input[1..];
}