using System.Text.Json;

namespace CinemaBox.Utilities.Json;


public static class JsonExtensions
{
    public static JsonElement? GetPropertySafe(this JsonElement element, string propertyName)
    {
        if (element.ValueKind == JsonValueKind.Object && element.TryGetProperty(propertyName, out var prop))        
            return prop;        
        return default;
    }

    public static JsonElement? GetPropertySafe(this JsonElement? element, string propertyName)
    {
        if (element.HasValue && element.Value.ValueKind == JsonValueKind.Object && element.Value.TryGetProperty(propertyName, out var prop))        
           return prop;        
        return default;
    }
}