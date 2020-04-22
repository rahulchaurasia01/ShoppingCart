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

        // GET: Product
        public string Index()
        {
            return "Hola";
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductModel productModel)
        {

            try
            {
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

                    }
                    else
                    {

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