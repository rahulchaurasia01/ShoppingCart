using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ShoppingCart.Models;
using ShoppingCartBusinessLayer.Interface;
using ShoppingCartCommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        public ActionResult Index()
        {
            List<ProductResponseModel> products = _productBusiness.GetAllProduct();

            return View(products);
        }


        /// <summary>
        /// It show the view for Adding Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// User Entered Product Details is added to the Database
        /// </summary>
        /// <param name="productModel">Product Data</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductModel productModel)
        {

            try
            {
                ViewBag.ProductStatus = false;
                if (ModelState.IsValid)
                {
                    HttpPostedFileBase productImage = productModel.Image;
                    string productImagePath = UploadProductImageToCloudinary(productImage);

                    ProductRequestModel productRequest = new ProductRequestModel
                    {
                        Name = productModel.Name,
                        Image = productImagePath,
                        Quantity = productModel.Quantity,
                        Price = productModel.Price
                    };

                    ProductResponseModel product = _productBusiness.Add(productRequest);

                    if (product == null)
                    {
                        ViewBag.ProductStatus = false;
                        ModelState.AddModelError("", "Unable to Add the Product.");
                    }
                    else
                    {
                        ViewBag.ProductStatus = true;
                        ViewBag.ProductMessage = "Product Has Been Successfully Added";
                        ModelState.Clear();
                    }
                }

                return View();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// It Show the details of single Product
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Details(int productId)
        {
            ProductResponseModel product = _productBusiness.Details(productId);
            return View(product);
        }





        /// <summary>
        /// It Upload Product Image to Cloudinary
        /// </summary>
        /// <param name="productImage">Product Image</param>
        /// <returns>Image Path</returns>
        [NonAction]
        private string UploadProductImageToCloudinary(HttpPostedFileBase productImage)
        {
            try
            {

                var Account = new Account(ConfigurationManager.AppSettings["Cloud_Name"],
                    ConfigurationManager.AppSettings["Api_Key"], ConfigurationManager.AppSettings["Api_Secret"]);

                Cloudinary cloudinary = new Cloudinary(Account);

                var imageUpload = new ImageUploadParams
                {
                    File = new FileDescription(productImage.FileName, productImage.InputStream),
                    Folder = "Shopping Cart"
                };

                var uploadImage = cloudinary.Upload(imageUpload);

                return uploadImage.SecureUri.AbsoluteUri;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
               
    }
}