using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_DemoProject.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, MaxLength(200)]
        public string Author { get; set; }
        [Required, MaxLength(2000)]
        public string Desciption { get; set; }
        [ForeignKey("Category")]
        public int CatId { get; set; }
        public Category Category { get; set; }
        public DateTime AddedOn { get; set; }
        public Book()
        {
            AddedOn = DateTime.Now;
        }

    }
}