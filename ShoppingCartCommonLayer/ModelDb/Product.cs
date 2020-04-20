using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCommonLayer.ModelDb
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { set; get; }

        [Required]
        public string Name { set; get; }

        public string Image { set; get; }

        [Required]
        public int Quantity { set; get; }

        [Required]
        public int Price { set; get; }

        public DateTime CreatedAt { set; get; }

        public DateTime ModifiedAt { set; get; }

    }
}
