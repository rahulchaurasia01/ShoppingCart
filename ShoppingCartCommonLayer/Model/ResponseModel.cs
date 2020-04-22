using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartCommonLayer.Model
{

    /// <summary>
    /// It's a response Model When Product is Added Successfully.
    /// </summary>
    public class ProductResponseModel
    {

        public int ProductId { set; get; }

        public string Name { set; get; }

        public string Image { set; get; }

        public int Quantity { set; get; }

        public int Price { set; get; }

        public DateTime CreatedAt { set; get; }

        public DateTime ModifiedAt { set; get; }

    }

}
