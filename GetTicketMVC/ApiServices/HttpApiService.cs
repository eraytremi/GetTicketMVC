using Microsoft.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
namespace GetTicketMVC.ApiServices
{
  public class HttpApiService : IHttpApiService
  {
    private readonly IHttpClientFactory _httpClientFactory;
    // IHttpClientFactory tipindeki nesneyi kullanarak HttpClient nesnesini IoC containerdan elde edeceğiz. Bu şekilde HttpClient nesnesi elde etmek performans açısından best practice'dir. Çünkü bu şekilde elde etmek, tek bir request içerisinde hep aynı obje kullanılacağı için bellek yönetimi açısından en iyisidir. 

    public HttpApiService(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

        public async Task<T> GetByIdData<T>(string requestUri,int id, string token = null)
        {
            T response = default(T);

            // Servise göndereceğim request : 
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:7080/api{requestUri}/{id}"),
                Headers =
            {
              {HeaderNames.Accept,"application/json" }
            }
            };

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.SendAsync(requestMessage);

            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();


            response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


            return response;

        }

        public async Task<T> GetData<T>(string requestUri, string token = null) 
    {
      T response = default(T);

      // Servise göndereceğim request : 
      var requestMessage = new HttpRequestMessage()
      {
        Method = HttpMethod.Get,
        RequestUri = new Uri($"https://localhost:7080/api{requestUri}"),
        Headers =
        {
          {HeaderNames.Accept,"application/json" }
        }
      };

            if (!string.IsNullOrEmpty(token))
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
      // servisle haberleşecek olan HttpClient nesnesi elde ediliyor : 
      var client = _httpClientFactory.CreateClient();

      // servise request gönderiliyor : 
      var responseMessage = await client.SendAsync(requestMessage);

      // servisden gelen yanıt T tipine dönüşütürülüyor :
        var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

        
            
            response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

      // servisden gelen yanıt T tipinde döndürülüyor
      return response;
    }

    public async Task<T> PostData<T>(string requestUri, string jsonData, string token = null)
    {

      T response = default(T);

      var requestMessage = new HttpRequestMessage()
      {
        Method = HttpMethod.Post,
        RequestUri = new Uri($"https://localhost:7080/api{requestUri}"),
        Headers =
        {
          {HeaderNames.Accept,"application/json" }
        },
        Content = new StringContent(jsonData,Encoding.UTF8,"application/json")
      };

      var client = _httpClientFactory.CreateClient();

      var responseMessage = await client.SendAsync(requestMessage);
    
      var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

      response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

      return response;
    }

        public async Task<T> RemoveData<T>(string requestUri, int id, string token = null)
        {
            T response = default(T);

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://localhost:7080/api{requestUri}/{id}"),
                Headers =
                {
                  {HeaderNames.Accept,"application/json" }
                },
               
            };

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.SendAsync(requestMessage);

            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

            response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return response;
        }

        public async Task<T> UpdateData<T>(string requestUri, string jsonData, string token = null)
        {

            T response = default(T);

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7080/api{requestUri}"),
                Headers =
                {
                  {HeaderNames.Accept,"application/json" }
                },
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.SendAsync(requestMessage);

            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

            response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return response;
        }
    }
}
