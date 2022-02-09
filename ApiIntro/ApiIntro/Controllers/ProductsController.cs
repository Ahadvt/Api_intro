using ApiIntro.Data.Dal;
using ApiIntro.Data.Enteties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIntro.Controllers
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet("")]

        public IActionResult GetAll()
        {
            return StatusCode(200, _context.Products.ToList());
        }

        [HttpPost("")]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201,product);
        }

        [HttpPut("")]
        public IActionResult Edit(Product product)
        {
            Product ExsistProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (ExsistProduct == null) return NotFound();

            ExsistProduct.Name = product.Name;
            ExsistProduct.SalePrice = product.SalePrice;
            ExsistProduct.CostPrice = product.CostPrice;
            ExsistProduct.CategoryId = product.CategoryId;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
