namespace API.ApiResponse
{
    public class ServiceResponse<T>
    {
        // Hata olusabilecek bazi isteklere generic bir yanıt olusturduk. Hata var ise bu nesnenin mesaj özelligi ile gösterilir.

        public T data {get;set;}
        public bool Basari { get; set; } = true;
        public string Mesaj { get; set; } = null;
    }
}