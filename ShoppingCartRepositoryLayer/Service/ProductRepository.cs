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

    }
}
