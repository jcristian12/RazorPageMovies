using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Data;
using RazorPageMovies.Models;

namespace RazorPageMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovies.Data.RazorPageMoviesContext _context;

        public IndexModel(RazorPageMovies.Data.RazorPageMoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Generos { get; set; }
        [BindProperty(SupportsGet = true)]

        public string? MovieGenero { get; set; }


        public async Task OnGetAsync()
        {
            //Movie = await _context.Movie.ToListAsync();

            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            var movies = from m in _context.Movie select m;

            if (!string.IsNullOrEmpty(SearchString)) 
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenero))
            {
                movies = movies.Where(x => x.Genre == MovieGenero);
            }

            if (_context.Movie != null) 
            {
                Generos = new SelectList(await genreQuery.Distinct().ToListAsync());
                Movie = await movies.ToListAsync();
            }

            

        }
    }
}
