

using System.Text;
using System.Text.Json;

namespace SHC.UI.Shared.Common;

public class Serializer
{
    public static StringContent ToStringContent(object o)
    {
        var json = JsonSerializer.Serialize(o);

        return new StringContent(json, Encoding.UTF8, "application/json");
    }
    public static async Task<T?> ReadFromHttpContentAsync<T>(HttpContent content)
    {
        using var stream = await content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }
}
