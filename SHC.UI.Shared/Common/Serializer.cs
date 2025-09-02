

using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace SHC.UI.Shared.Common;

public class Serializer
{
    public static JsonSerializerOptions options = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true
    };
    public static StringContent ToStringContent(object o)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var json = JsonSerializer.Serialize(o);

        return new StringContent(json, Encoding.UTF8, "application/json");
    }
    public static async Task<T?> ReadFromHttpContentAsync<T>(HttpContent content)
    {
        // body = await content.ReadAsStringAsync();
        using var stream = await content.ReadAsStreamAsync();

        return await JsonSerializer.DeserializeAsync<T>(stream, options);
    }
}
