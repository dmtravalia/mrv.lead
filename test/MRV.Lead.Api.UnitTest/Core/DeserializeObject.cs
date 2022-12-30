using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MRV.Lead.Api.UnitTest.Core;

public static class DeserializeObject
{
    public static async Task<IEnumerable<T>> GetListDeserializeObjectAsync<T>(this HttpResponseMessage response) where T : class
    {
        var jsonResult = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonResult);
    }

    public static async Task<T> GetDeserializeObjectAsync<T>(this HttpResponseMessage response) where T : class
    {
        var jsonResult = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(jsonResult);
    }
}