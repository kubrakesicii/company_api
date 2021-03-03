namespace Core.Entities
{
    public class CalisanDepartman
    {
        // Calisan ve Departman tablolari arasında many-to-many iliskisi saglayan tablodur.
        // Bu yüzden iki tablonun key degerleri alinir.
        
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }
        public int DepartmanId { get; set; }
        public Departman Departman { get; set; }
    }
}