namespace API.DTOs.Firma
{
    public class CalisanFirmasiGetirDto
    {
        //Calisanlarin firma bilgisini alırken bu firmanin Id ve Ad degerleri yeterlidir (Extra olan firma calisan sayisi degeri burada alinmaz)

        public int Id { get; set; }
        public string Ad { get; set; }
    }
}