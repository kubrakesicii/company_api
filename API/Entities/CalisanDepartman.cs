namespace Core.Entities
{
    public class CalisanDepartman
    {
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }
        public int DepartmanId { get; set; }
        public Departman Departman { get; set; }
    }
}