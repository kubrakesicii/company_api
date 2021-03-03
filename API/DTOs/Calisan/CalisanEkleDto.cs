namespace API.DTOs
{
    public class CalisanEkleDto
    {
        //Calisanların Id değeri veritabanında otomatik olarak verilir.
        //Eklenirken kullanıcının girmesine gerek yoktur.
        public string AdSoyad { get; set; }
        public int FirmaId { get; set; }
    }
}