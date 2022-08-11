using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SapereAude.Models
{
    public class Suggestion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Naslov/tema teksta")]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        public string Comment { get; set; }

        public Category Category { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Kategorija")]
        public int CategoryFK { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //public List<SelectListItem> CategoryList { get; set; }
    }
}
