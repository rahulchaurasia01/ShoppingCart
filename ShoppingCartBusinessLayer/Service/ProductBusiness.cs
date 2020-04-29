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

        /// <summary>
        /// It Return the Product Details
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Product Response Model</returns>
        public ProductResponseModel Details(int productId)
        {
            try
            {
                if (productId <= 0)
                    return null;
                else
                    return _productRepository.Details(productId);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// It fetches all the Product
        /// </summary>
        /// <returns>List of all Product Response Model</returns>
        public List<ProductResponseModel> GetAllProduct()
        {
            try
            {
                return _productRepository.GetAllProduct();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
