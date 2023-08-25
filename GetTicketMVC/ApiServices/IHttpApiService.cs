namespace GetTicketMVC.ApiServices
{ 
  public interface IHttpApiService
  {
  
    Task<T> GetData<T>(string requestUri,string token=null);
    Task<T> PostData<T>(string requestUri,string jsonData, string token = null);
    Task<T> UpdateData<T>(string requestUri, string jsonData, string token = null);
    Task<T> GetByIdData<T>(string requestUri, int id, string token = null);
    Task<T> RemoveData<T>(string requestUri, int id, string token = null);

    }
}
