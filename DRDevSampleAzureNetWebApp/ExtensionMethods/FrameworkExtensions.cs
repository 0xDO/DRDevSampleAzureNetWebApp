using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
 
namespace DRDevSampleAzureNetWebApp.FrameworkExtensions {
  /// <summary>
  /// 
  /// </summary>
  public static class HttpContentExtensions {

    /// <summary>
    /// Reads as json asynchronous.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="content">The content.</param>
    /// <returns></returns>
    public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content) {
      string json = await content.ReadAsStringAsync();
      T value = JsonConvert.DeserializeObject<T>(json);
      return value;
    }

  }
}