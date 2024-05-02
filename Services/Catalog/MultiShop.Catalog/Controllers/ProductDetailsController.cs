using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productdetailService;

        public ProductDetailsController(IProductDetailService productdetailService)
        {
            _productdetailService = productdetailService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productdetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = await _productdetailService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productdetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail Added Successfuly");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productdetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail Deleted Successfuly");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productdetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("ProductDetail Updated Successfuly");
        }

    }
}
