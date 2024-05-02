using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageService _productimageService;

    public ProductImagesController(IProductImageService productimageService)
    {
        _productimageService = productimageService;
    }
    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        var values = await _productimageService.GetAllProductImageAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var value = await _productimageService.GetByIdProductImageAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await _productimageService.CreateProductImageAsync(createProductImageDto);
        return Ok("ProductImage Added Successfuly");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _productimageService.DeleteProductImageAsync(id);
        return Ok("ProductImage Deleted Successfuly");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await _productimageService.UpdateProductImageAsync(updateProductImageDto);
        return Ok("ProductImage Updated Successfuly");
    }

}
