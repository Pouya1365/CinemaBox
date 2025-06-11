using System.Text.Json;

namespace CinemaBox.Utilities.Json;

public static class JsonExtensions
{
    public static JsonElement? GetPropertySafe(this JsonElement element, string propertyName) => element.TryGetProperty(propertyName, out JsonElement value) ? value : (JsonElement?)null;
}