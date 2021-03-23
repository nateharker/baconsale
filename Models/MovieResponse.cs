using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baconsale.Models
{
    public class MovieResponse
    {
        [Key] //Unique identifier for each entry in the DB, automatically generated
        [Required]
        public int MovieResponseId { get; set; }
        [Required]
        public string Category{ get; set; }
        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage ="The Year value is required")]
        [Range(1888,9999, ErrorMessage = "Year must be later than 1888")] //The First movie ever was made in 1888, so nothing earlier than that should be allowed
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; } 
        public string LentTo { get; set; }
        [MaxLength(25, ErrorMessage = "Note has a max length of 25 characters")]
        public string Notes { get; set; }
    }
}
