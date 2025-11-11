using System.Reflection;
using Oprim.Application.Identities;

namespace Oprim.Ui;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPermissionPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            var permissionFields = typeof(Permissions)
                .GetNestedTypes(BindingFlags.Public | BindingFlags.Static)
                .SelectMany(t => t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
                .Where(f => f.IsLiteral && !f.IsInitOnly)
                .ToList();

            foreach (var field in permissionFields)
            {
                var permissionValue = field.GetValue(null)?.ToString();
                if (!string.IsNullOrWhiteSpace(permissionValue))
                {
                    options.AddPolicy(permissionValue,
                        policy => policy.RequireClaim("Permission", permissionValue));
                }
            }
        });

        return services;
    }
}