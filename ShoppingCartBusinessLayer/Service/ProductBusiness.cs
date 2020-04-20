using ShoppingCartBusinessLayer.Interface;
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

    }
}
