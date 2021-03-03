namespace API.DTOs
{
    public class CalisanDepartmaniEkleDto
    {
        // Belirli bir calisana , görev alabilecegi departmanlar sonradan eklenir.
        // Bunun icin departman ekleyecegimiz calisan id'si ve eklenecek departman id'si yeterlidir.
        
        public int CalisanId { get; set; }
        public int DepartmanId { get; set; }
    }
}