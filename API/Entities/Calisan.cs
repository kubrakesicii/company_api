using System;
using System.Collections.Generic;
using API.Entities;

namespace Core.Entities
{
    public class Calisan
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }

        //Her calisan yalnız 1 Firmaya bağlıdır
        public int FirmaId { get; set; }
        public Firma Firma { get; set; }

        //Her Calisan birden fazla Departmanda görev alabilir ve
        //her Departmanda birden fazla Calisan olabilir -> many to many iliski mevcut
        // **CalisanDepartman tablosu bu iliskiyi saglayan joining tablosudur.
        public List<CalisanDepartman> CalisanDepartmanlari { get; set; }

    }
}