using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCommonLayer.ModelDb
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        public int ProductId { set; get; }
        
        [ForeignKey("ProductId")]
        public Product Product { set; get; }

        [StringLength(255)]
        [Required]
        public string Address { set; get; }

        public int ProductQuantity { set; get; }

        public int Price { set; get; }

        public DateTime CreatedAt { set; get; }

        public DateTime ModifiedAt { set; get; }



    }
}
