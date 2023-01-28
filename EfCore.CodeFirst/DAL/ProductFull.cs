using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.DAL
{
    [Keyless]
    // store procedure için oluşturulan model migrate esnasında db de tablo karşıolığı olamması için
    //[NotMapped]
    public class ProductFull
    {
        public int Product_Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Height { get; set; }
    }
}
