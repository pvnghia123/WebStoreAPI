namespace WebStoreAPI.Models
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        public string ErrorMessage { get; set; }
    }
}
