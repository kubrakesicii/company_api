using System.Collections.Generic;

namespace Core.Entities
{
    public class Departman
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        //Her calisan birden fazla departmanda görev alabilir ve
        //her departmanda birden fazla calisan olabilir -> many to many iliski mevcut
        // **CalisanDepartman tablosu bu iliskiyi saglayan joining tablosudur.
        public List<CalisanDepartman> CalisanDepartmanlari { get; set; }
    }
}