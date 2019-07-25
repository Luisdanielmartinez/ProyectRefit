

namespace ProyectRefit.Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Product
    {
        [Display(Name = "Image")]
        public string Image { get; set; }
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        [StringLength(30)]
        public string Name{ get;set;}
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "IsAvalible")]
        [Required]
        public bool IsAvalible { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

    }
}
