using AutoMapper;
using BusinessLogic.Helpers;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using Website.Helpers;
using Website.ViewModels.ProductVM;

namespace Website.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IStoragePathHelper _storagePathHelper;

        public ProductController(IProductService productService, IMapper mapper, IStoragePathHelper storagePathHelper)
        {
            _productService = productService;
            _mapper = mapper;
            _storagePathHelper = storagePathHelper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<List<ProductViewModel>>(products));
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Json(_mapper.Map<ProductViewModel>(product));
        }

        //public IActionResult CreateProduct()
        //{
            // is used to make initial state, form view model
            // to use that please configure model factory and using DI add services needed
        //}

        /// <summary>
        /// Create a new Product.
        /// </summary>
        /// <param name="product">A ProductDTO.</param>
        [HttpPost("create")]
        [ValidateModel]
        public async Task<IActionResult> CreateProduct([FromBody] ProductFormViewModel product)
        {
            //if (product.IsFileUploaded)
            //{
            //    product = UploadFile(file, product);
            //    product.AttachmentType = AttachmentType.Upload;
            //}

            var newProduct = _mapper.Map<Product>(product);
            newProduct.CreateDate = DateTime.Now;

            await _productService.AddAsync(newProduct);

            return Ok();
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            var model = _mapper.Map<ProductFormViewModel>(product);

            return Json(model);
        }

        [HttpPut("update")]
        [ValidateModel]
        public async Task<IActionResult> EditProduct([FromBody] ProductFormViewModel model)
        {
            //if (model.IsFileUploaded)
            //{
            //    model = UploadFile(file, model);
            //    model.AttachmentType = AttachmentType.Upload;
            //}

            var product = await _productService.GetByIdAsync(model.Id);

            product = _mapper.Map(model, product);
            await _productService.UpdateAsync(product);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            await _productService.DeleteAsync(product);

            return Ok();
        }

        [HttpPost("deleteSelectedProducts")]
        public async Task<IActionResult> DeleteSelectedProducts(int[] selectedIds)
        {
            List<Product> products = new List<Product>();

            foreach (var id in selectedIds)
            {
                var product = await _productService.GetByIdAsync(id);
                products.Add(product);
            }

            if (products.Count > 0)
                await _productService.DeleteAsync(products);

            return Ok();
        }

        //private ProductFormViewModel UploadFile(IFormFile file, ProductFormViewModel product)
        //{
        //    var fileName = $"{product.Name}-${Guid.NewGuid()}-{file.FileName}";
        //    var dirPath = _storagePathHelper.ProductImagesPathString();
        //    var filePath = Path.Combine(dirPath, fileName);

        //    if (System.IO.File.Exists(filePath))
        //        return product;

        //    Directory.CreateDirectory(dirPath);

        //    using (var output = System.IO.File.OpenWrite(filePath))
        //    {
        //        file.CopyTo(output);
        //    }

        //    product.ImageLink = filePath;
        //    return product;
        //}

        //private async Task<IActionResult> DownloadImage(Product product)
        //{
        //    if (System.IO.File.Exists(product.ImageLink))
        //    {
        //        var dataBytes = System.IO.File.ReadAllBytes(product.ImageLink);
        //        var dataStream = new MemoryStream(dataBytes);

        //        return File(dataStream, "application/octet-stream");
        //    }

        //    return NotFound(new { message = "File not found!" });
        //}
    }
}
