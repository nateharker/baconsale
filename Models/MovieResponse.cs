using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baconsale.Models
{
    public class MovieResponse
    {
        [Required]
        public string Category{ get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888,9999, ErrorMessage = "Year must be later than 1888")] //The First movie ever was made in 1888, so nothing earlier than that should be allowed
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; } //the value '' is invalid, even though it's not required
        public string LentTo { get; set; }
        [MaxLength(25, ErrorMessage = "Note has a max length of 25 characters")]
        public string Notes { get; set; }
    }
}
