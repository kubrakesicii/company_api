namespace API.DTOs
{
    public class FirmaGetirDto
    {
        // Tüm firmaları calisan sayilariyla beraber listelemek icin kullanilir
        
        public int Id { get; set; }
        public string Ad { get; set; }
        public int CalisanSayisi { get; set; }
    }
}