namespace API.ApiResponse
{
    public class ServiceResponse<T>
    {
        public T data {get;set;}
        public bool Basari { get; set; } = true;
        public string Mesaj { get; set; } = null;
    }
}