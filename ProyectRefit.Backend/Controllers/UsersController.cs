

namespace ProyectRefit.Backend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ProyectRefit.Backend.bdContext;
    using ProyectRefit.Backend.Models;

    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;
        public UsersController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<User> GET()
        {
            return _context.Users.ToList();
        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var user = _context.Users.Include(x => x.Id).FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("createUser")]
        public ActionResult POST([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return new CreatedAtRouteResult("creado", new { user });
            }
            return BadRequest(ModelState);

        }
    }
}