using BusinessLayer.Interfaces;
using BusinessObjectLayer;
using GroceryStoreAPI.Helper;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL _productBL;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductBL productBL, IWebHostEnvironment environment)
        {
            _productBL = productBL;
            _environment = environment;
        }

        [HttpPost]
        [Route("post")]
        public int Post([FromBody] Product value)
        {
            if(value != null)
            {
                ProductObject product = new ProductToProductObjectHelper().ProductToProductObjectMapping(value);
                if (ModelState.IsValid)
                {
                    return _productBL.AddProduct(product);
                }
            }
            return 0;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<ProductObject> products = _productBL.GetAllProducts();
            var product = new ProductObjectToProductHelper().GetProduct(products);
            foreach(var prod in product)
            {
                prod.Image = GetImageUrlByProduct(prod.ProductId);
            }
            return product;
        }

        [HttpGet("{id}")]
        [Route("GetProductById/{id}")]
        public Product GetProductById(int id)
        {
            ProductObject car = _productBL.GetProductById(id);
            if (car != null)
            {
                var prod = new ProductObjectToProductHelper().ProductObjectToProductMapping(car);
                prod.Image = GetImageUrlByProduct(id);
                return prod;
            }
            return null;
        }

        [HttpGet("{id}")]
        [Route("EditProductById/{id}")]
        public bool EditProductById(int id, [FromBody] Product value)
        {
            if(value != null)
            {
                ProductObject product = new ProductToProductObjectHelper().ProductToProductObjectMapping(value);
                product.ProductId = id;
                if (_productBL.EditProductById(product))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        [HttpGet("{id}")]
        [Route("DeleteProduct/{id}")]
        public bool DeleteProduct(int id)
        {
            var value = _productBL.DeleteProduct(id);
            string ProductId = id.ToString();
            if(value == true)
            {
                string imagePath1 = this._environment.WebRootPath + "\\Uploads\\" + ProductId + ".jpg";
                string imagePath2 = this._environment.WebRootPath + "\\Uploads\\" + ProductId + ".png";

                if (System.IO.File.Exists(imagePath1))
                {
                    System.IO.File.Delete(imagePath1);
                }
                if (System.IO.File.Exists(imagePath2))
                {
                    System.IO.File.Delete(imagePath2);
                }
            }
            return value;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public IEnumerable<string> GetAllCategory()
        {
            var value = _productBL.GetAllCategory();
            return value;
        }

        [HttpPost]
        [Route("UploadImage")]
        public bool UploadImage()
        {
            bool result = false;
            try
            {
                var _uploadfiles = Request.Form.Files;
                foreach (IFormFile source in _uploadfiles)
                {
                    string Filename = source.FileName;
                    string FileType = source.ContentType;

                    string imagePath = GetImagePath(Filename, FileType);
                    string imagePath1 = this._environment.WebRootPath + "\\Uploads\\" + Filename + ".jpg";
                    string imagePath2 = this._environment.WebRootPath + "\\Uploads\\" + Filename + ".png";

                    if (System.IO.File.Exists(imagePath1))
                    {
                        System.IO.File.Delete(imagePath1);
                    }
                    if (System.IO.File.Exists(imagePath2))
                    {
                        System.IO.File.Delete(imagePath2);
                    }

                    using (FileStream stream = System.IO.File.Create(imagePath))
                    {
                        source.CopyTo(stream);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return result;
        }

        [NonAction]
        private string GetImagePath(string ProductId, string FileType)
        {
            if (FileType == "image/png")
            {
                return this._environment.WebRootPath + "\\Uploads\\" + ProductId + ".png";
            }
            else
            {
                return this._environment.WebRootPath + "\\Uploads\\" + ProductId + ".jpg";
            }
        }

        [NonAction]
        private string GetImageUrlByProduct(int ProductId)
        {
            string str = ProductId.ToString();
            string ImgUrl = string.Empty;
            string HostUrl = $"{this.Request.Scheme}://{this.Request.Host}/";

            string imagePath1 = this._environment.WebRootPath + "\\Uploads\\" + str + ".jpg";
            string imagePath2 = this._environment.WebRootPath + "\\Uploads\\" + str + ".png";
            if (System.IO.File.Exists(imagePath1))
            {
                ImgUrl = HostUrl + "Uploads/" + str + ".jpg";
            }
            if (System.IO.File.Exists(imagePath2))
            {
                ImgUrl = HostUrl + "Uploads/" + str + ".png";
            }
            return ImgUrl;
        }

        [HttpPost("{id}")]
        [Route("OrderProduct/{id}")]
        public bool OrderProduct(int id, IEnumerable<ProductOrder> productList)
        {
            var prod = new ProductOrderToProductOrderObjectHelper().GetProductShared(productList);
            var t = _productBL.OrderProduct(id, prod);
            if (t == true)
            {
                foreach (var pro in productList)
                {
                    if (!UpdateQuantity(pro))
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        [NonAction]
        private bool UpdateQuantity([FromBody] ProductOrder product)
        {
            if (_productBL.UpdateQuantity(product.ProductId, product.OrderedQuantity))
            {
                return true;
            }
            return false;
        }

        [HttpGet("{id}")]
        [Route("GetMyOrders/{id}")]
        public IEnumerable<MyOrders> GetMyOrders(int id)
        {
            IEnumerable<MyOrders> productList = _productBL.GetMyOrders(id);
            foreach (MyOrders p in productList)
            {
                p.Image = GetImageUrlByProduct(p.ProductId);
            }
            return productList;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
