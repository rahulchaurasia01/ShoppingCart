using ShoppingCartCommonLayer.Model;
using ShoppingCartCommonLayer.ModelDb;
using ShoppingCartRepositoryLayer.Interface;
using ShoppingCartRepositoryLayer.ModelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartRepositoryLayer.Service
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationContext _applicationContext;

        public ProductRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        /// <summary>
        /// It Add the Product to the Db.
        /// </summary>
        /// <param name="productRequest">Product Details</param>
        /// <returns>If Added Successfull, It return ProductResponseModel or else Null</returns>
        public ProductResponseModel Add(ProductRequestModel productRequest)
        {
            try
            {
                var product = new Product
                {
                    Name = productRequest.Name,
                    Image = productRequest.Image,
                    Quantity = productRequest.Quantity,
                    Price = productRequest.Price,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };

                _applicationContext.Products.Add(product);
                _applicationContext.SaveChanges();

                ProductResponseModel productResponse = new ProductResponseModel
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Image = product.Image,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CreatedAt = product.CreatedAt,
                    ModifiedAt = product.ModifiedAt
                };

                return productResponse;

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// It Return the Product Detais
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Product Response Model</returns>
        public ProductResponseModel Details(int productId)
        {
            try
            {
                Product product = _applicationContext.Products.Where(pdt => pdt.ProductId == productId).FirstOrDefault();

                if(product != null)
                {
                    ProductResponseModel productResponse = new ProductResponseModel
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Image = product.Image,
                        Quantity = product.Quantity,
                        Price = product.Price,
                        CreatedAt = product.CreatedAt,
                        ModifiedAt = product.ModifiedAt
                    };

                    return productResponse;
                }

                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// It Fetches all the Product.
        /// </summary>
        /// <returns>List of all the product</returns>
        public List<ProductResponseModel> GetAllProduct()
        {
            try
            {
                List<ProductResponseModel> products = _applicationContext.Products.
                    Select(product => new ProductResponseModel
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Image = product.Image,
                        Quantity = product.Quantity,
                        Price = product.Price,
                        CreatedAt = product.CreatedAt,
                        ModifiedAt = product.ModifiedAt
                    }).
                    ToList();

                return products;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
