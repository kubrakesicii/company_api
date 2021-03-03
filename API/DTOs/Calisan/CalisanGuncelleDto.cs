namespace API.DTOs.Calisan
{
    public class CalisanGuncelleDto
    {
        //Bu DTO sadece ilgili çalışanın Firma'sının güncellemek için kullanılacak
        //Bu yüzden sadece Calisan Id ve Firma Id yeterlidir

        public int CalisanId { get; set; }
        public int YeniFirmaId { get; set; }
    }
}