using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectRefit.Backend.bdContext;
using ProyectRefit.Backend.Models;

namespace ProyectRefit.Backend.Controllers
{
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;
        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> GET()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{Id}", Name ="creado")]
        public ActionResult GetById(int Id)
        {
            var Product = _context.Products.FirstOrDefault(x => x.Id ==Id);
            if (Product==null)
            {
                return NotFound();
            }
            return Ok(Product);
        }
        [HttpPost]
        public ActionResult POST([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return new CreatedAtRouteResult("creado", new { id=product.Id});
            }
            return BadRequest(ModelState);

        }
    }
}