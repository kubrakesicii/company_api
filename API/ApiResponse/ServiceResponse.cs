namespace API.ApiResponse
{
    public class ServiceResponse<T>
    {
        public T data {get;set;}
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}