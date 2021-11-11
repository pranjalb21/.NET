using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title are required")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [StringLength(255, MinimumLength = 5, ErrorMessage = "Minimum 5 character is required.")]
        [Required(ErrorMessage = "Author is are required")]
        [DataType(DataType.Text)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Description required")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Source { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage = "Number of pages are required")]
        public int? Pages { get; set; }
    }
}
