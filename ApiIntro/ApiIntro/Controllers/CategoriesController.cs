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
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpGet("")]

        public IActionResult GetAll()
        {
            return StatusCode(200, _context.Categories.ToList());
        }

        [HttpPost("")]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return StatusCode(201, category);
        }

        [HttpPut("")]
        public IActionResult Edit(Category category)
        {
            Category ExsistCategory = _context.Categories.FirstOrDefault(p => p.Id == category.Id);
            if (ExsistCategory == null) return NotFound();

            ExsistCategory.Name = category.Name;
          

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
