using System.Collections.Generic;

namespace API.DTOs.Departman
{
    public class DepartmanaGöreCalisanGetirDto
    {
        // Bu DTO, calisanlari departmanlarına göre gruplandırabilmek için kullanılacak.

        // İlgili Departman ID'si
         public int DepartmanId { get; set; }

         //Bu Departmanda görev alan Calisanlarin Listesi
        public List<CalisanFirmaDto> Calisanlar { get; set; }
    
    }
}