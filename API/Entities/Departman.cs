using System.Collections.Generic;

namespace Core.Entities
{
    public class Departman
    {
        public int Id { get; set; }
        public string Ad { get; set; }

       //Her Calisan birden fazla Departmanda görev alabilir ve her Departmanda birden fazla Calisan olabilir 
        // --> many to many iliski mevcut
        // **CalisanDepartman tablosu bu iliskiyi saglayan join tablosudur.
        public List<CalisanDepartman> CalisanDepartmanlari { get; set; }
    }
}