using backend.Context;
using backend.Dtos;
using backend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // CRUD -> Create - Read - Update - Delete

        // Create
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProducts dto)
        {
            var newProduct = new Entity()
            {
                Brand = dto.Brand,
                Title = dto.Title,
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return Ok("Product Saved Successfully");
        }

        // Read
        [HttpGet]
        public async Task<ActionResult<List<Entity>>> GetAllProducts()
        {
            var products = await _context.Products.OrderByDescending(q => q.UpdatedAt).ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Entity>> GetProductByID([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            return Ok(product);
        }

        // Update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UdpateProduct([FromRoute] long id, [FromBody] CreateUpdateProducts dto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            product.Title = dto.Title;
            product.Brand = dto.Brand;
            product.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok("Product Updated Successfully");
        }

        // Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok("Product Deleted Successfully");
        }
    }
}