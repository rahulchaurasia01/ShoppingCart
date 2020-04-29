using ShoppingCartCommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartRepositoryLayer.Interface
{
    public interface IProductRepository
    {

        ProductResponseModel Add(ProductRequestModel productRequest);

        ProductResponseModel Details(int productId);

        List<ProductResponseModel> GetAllProduct();


    }
}
