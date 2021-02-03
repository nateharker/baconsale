using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baconsale.Models
{
    public class TempStorage
    {
        private static List<MovieResponse> movies = new List<MovieResponse>();

        public static IEnumerable<MovieResponse> Movies => movies;

        public static void AddMovie(MovieResponse movie)
        {
            movies.Add(movie);
        }
    }
}
