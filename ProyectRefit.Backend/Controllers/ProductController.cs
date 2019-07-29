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

        [HttpGet]
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
                return new CreatedAtRouteResult("creado", new {product});
            }
            return BadRequest(ModelState);

        }
    }
}