﻿using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using SurfStoreApp.Models;
using SurfStoreApp.Utils;

namespace SurfStoreApp.Controllers
{
    public class SurfController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(string category)
        {
            List<ProductModel> productModel = new List<ProductModel>();

            // Check if a category was passed in first.
            if (!string.IsNullOrWhiteSpace(category))
            {
                // Retrieve the product images
                Utils.ImageUtils imageUtils = new ImageUtils();
                var productImages = imageUtils.RetrieveProductImages(category);

                // Loop through and add to our Model
                foreach (FileInfo productImage in productImages)
                {
                    string imagePath = "~/Content/Images/" + category + "/" + productImage.Name;

                    productModel.Add(new ProductModel { ImageDescription = productImage.Name.Replace(productImage.Extension, ""), ImageUrl = imagePath });
                }
            }

            return View(productModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
