using ShoppingCartBusinessLayer.Interface;
using ShoppingCartBusinessLayer.Service;
using ShoppingCartRepositoryLayer.Interface;
using ShoppingCartRepositoryLayer.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ShoppingCart
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IProductBusiness, ProductBusiness>();
            container.RegisterType<IProductRepository, ProductRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}