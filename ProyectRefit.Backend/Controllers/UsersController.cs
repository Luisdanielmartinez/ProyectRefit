

namespace ProyectRefit.Backend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ProyectRefit.Backend.bdContext;
    using ProyectRefit.Backend.Models;

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
    }
}