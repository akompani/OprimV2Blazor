using System.Reflection;
using Oprim.Domain.Common;

namespace Oprim.Domain.Extensions.Methods;

public static class UpdateEntity
{
    public static void UpdateIfHasValue<T>(this T target, T source) where T : BaseEntity
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in properties)
        {
            if (!prop.CanRead || !prop.CanWrite)
                continue;

            var sourceValue = prop.GetValue(source);
            var defaultValue = GetDefault(prop.PropertyType);

            // نادیده گرفتن آی‌دی یا سایر فیلدهای خاص اگر نیاز بود
            if (prop.Name is "Id" or "InsertDate" or "UserId")
                continue;

            if (sourceValue == null || sourceValue.Equals(defaultValue))
                continue;

            prop.SetValue(target, sourceValue);
        }
    }

    private static object GetDefault(Type type)
    {
        return (type.IsValueType ? Activator.CreateInstance(type) : new object()) ?? new object();
    }
}