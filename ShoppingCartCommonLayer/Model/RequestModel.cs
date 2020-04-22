using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCommonLayer.Model
{

    /// <summary>
    /// It's the Request Model For adding Product
    /// </summary>
    public class ProductRequestModel
    {
        [Required(ErrorMessage = "Product Name is Required.")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Image Url Path Required.")]
        public string Image { set; get; }

        [Required(ErrorMessage = "Product Quantity is Required.")]
        [RegularExpression("^[1-9][0-9]{0,3}$", ErrorMessage = "Min 1 and Max 9999 Quantity Of the Product Required.") ]
        public int Quantity { set; get; }
        
        [Required(ErrorMessage = "Product Price is Required.")]
        [RegularExpression("^[1-9][0-9]{0,6}$", ErrorMessage = "Price Of the Product Should be More than 0")]
        public int Price { set; get; }

    }


}
