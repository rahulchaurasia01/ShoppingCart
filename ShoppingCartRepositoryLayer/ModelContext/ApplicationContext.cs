using ShoppingCartCommonLayer.ModelDb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartRepositoryLayer.ModelContext
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext() : base("ShoppingCartDb")
        {

        }

        public DbSet<Product> Products { set; get; }


    }
}
