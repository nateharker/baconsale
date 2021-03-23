using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace baconsale.Models
{
    //Context class acts as main connection between the app and the DB
    public class MovieListContext : DbContext
    {
        public MovieListContext (DbContextOptions<MovieListContext> options) : base(options)
        {

        }
        public DbSet<MovieResponse> Movies { get; set; }

    }
}
