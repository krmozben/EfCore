using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.CodeFirst2_forIsolation_.DAL
{
    public class ProductFeature
    {
        [Key,ForeignKey("Product")]
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        //public int Product_Id { get; set; }
        public Product Product { get; set; }
    }
}
