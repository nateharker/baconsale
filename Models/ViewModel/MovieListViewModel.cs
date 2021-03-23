using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baconsale.Models.ViewModel
{
    public class MovieListViewModel
    {
        //Preps the info to be sent to the view by putting it in an IEnumerable
        public IEnumerable<MovieResponse> Movies { get; set; }
    }
}
