namespace API.DTOs
{
    public class CalisanDepartmaniEkleDto
    {
        //Belirli bir calisana , görev alabilecegi departmanlar sonradan eklenir.
        
        public int CalisanId { get; set; }
        public int DepartmanId { get; set; }
    }
}