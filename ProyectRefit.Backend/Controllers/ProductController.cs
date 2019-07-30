using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectRefit.Backend.bdContext;
using ProyectRefit.Backend.Models;

namespace ProyectRefit.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;
        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public IEnumerable<Product> GET()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{Id}",Name ="creado")]
        public ActionResult GetById(int Id)
        {
            var Product = _context.Products.Include(x => x.user).FirstOrDefault(x => x.Id == Id);
            if (Product==null)
            {
                return NotFound();
            }
            return Ok(Product);
        }

        [HttpPost("create")]
        public ActionResult POST([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return new CreatedAtRouteResult("creado", new { id = product.Id });
            }
            return BadRequest(ModelState);

        }

        [HttpPut("update")]
        public async Task<ActionResult> put([FromBody] Product model)
        {
            try
            {
                var product = _context.Products.Single(x => x.Id == model.Id);
                product.Name = model.Name;
                product.IsAvalible = model.IsAvalible;
                product.Price = model.Price;
                product.Description = model.Description;
                product.Image = model.Image;
                _context.Update(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        [HttpDelete("{Id}")]
        public ActionResult delete(int Id)
        {
            var country = _context.Products.FirstOrDefault(x => x.Id == Id);
            if (country == null)
            {
                return NotFound();
            }
            _context.Products.Remove(country);
            _context.SaveChanges();
            return Ok(country);
        }
    }
}