using System.Collections.Generic;

namespace API.DTOs.Departman
{
    public class DepartmanaGöreCalisanGetirDto
    {
         public int DepartmanId { get; set; }
        public List<CalisanFirmaDto> Calisanlar { get; set; }
    
    }
}