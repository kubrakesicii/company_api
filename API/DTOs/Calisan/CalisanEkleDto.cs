namespace API.DTOs
{
    public class CalisanEkleDto
    {
        //Calisanların Id değeri veritabanında otomatik olarak verilir. (autoincrement)
        //Eklenirken kullanıcının girmesine gerek yoktur.
        
        public string AdSoyad { get; set; }
        public int FirmaId { get; set; }
    }
}