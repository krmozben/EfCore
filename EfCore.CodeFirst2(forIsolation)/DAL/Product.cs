using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst2_forIsolation_.DAL
{
    [Index(nameof(Name), nameof(Price))]
    [Index(nameof(Name))]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [NotMapped]
        public string Barcode { get; set; }
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
        //public bool IsDeleted { get; set; }
    }

    public class ProductDto
    {
   
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
