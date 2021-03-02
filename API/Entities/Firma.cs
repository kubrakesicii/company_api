using System.Collections.Generic;

namespace Core.Entities
{
    public class Firma
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Calisan> Calisanlar { get; set; }
        public List<Departman> Departmanlar { get; set; }
    }
}