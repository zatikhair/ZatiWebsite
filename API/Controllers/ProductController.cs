using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.ProductTable.ToListAsync();
            return Ok(products);
        }

        [HttpGet("getProductById/{id}")]
        public async Task<ActionResult<Product>> getProductById(int id) {
            var product = await _context.ProductTable.FindAsync(id);
            return Ok(product);
        } 
    }
}