namespace API.DTOs.Calisan
{
    public class CalisanGuncelleDto
    {
        //Bu DTO sadece ilgili çalışanın Firm'sının güncellemek için kullanılacak
        //Bu yüzden sadece Calisan Id ve Firma ID yeterli

        public int Id { get; set; }
        public int FirmaId { get; set; }
    }
}