using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVC5_DemoProject.Models;

namespace MVC5_DemoProject.ViewModels
{
    public class BookFormViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, MaxLength(200)]
        public string Author { get; set; }
        [Required, MaxLength(2000)]
        public string Desciption { get; set; }
        [ForeignKey("Category")]
        [Display(Name ="Category")]
        public int CatId { get; set; }
        public IEnumerable<Category>Categories { get; set; }
    }
}