using ShoppingCartBusinessLayer.Interface;
using ShoppingCartCommonLayer.Model;
using ShoppingCartRepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBusinessLayer.Service
{
    public class ProductBusiness : IProductBusiness
    {

        private readonly IProductRepository _productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// It Add the Product.
        /// </summary>
        /// <param name="productRequest">Product Details</param>
        /// <returns>Return true, If Added Successfully or else false</returns>
        public ProductResponseModel Add(ProductRequestModel productRequest)
        {
            try
            {
                if (productRequest == null)
                    return null;
                else
                    return _productRepository.Add(productRequest);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
