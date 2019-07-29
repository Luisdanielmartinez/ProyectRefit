

namespace ProyectRefit.Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Passowrd { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(30)]
        public string Address { get; set; }
        [StringLength(11)]
        public string Tell { get; set; }
    }
}
