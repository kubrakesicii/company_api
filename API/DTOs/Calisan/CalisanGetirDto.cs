using System;
using System.Collections.Generic;
using API.DTOs.Firma;
using Core.Entities;

namespace API.DTOs
{
    public class CalisanGetirDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public DateTime GirisTarihi { get; set; }
        public CalisanFirmasiGetirDto Firma { get; set; }
        public List<DepartmanGetirDto> Departmanlar { get; set; }
    }
}