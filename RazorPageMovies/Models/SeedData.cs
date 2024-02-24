using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Data;

namespace RazorPageMovies.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMoviesContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPageMoviesContext>>())) 
            {
                if(context == null) { 
                    throw new ArgumentNullException("Null RazorPagesMovies");
                }

                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    
                    new Movie 
                    { 
                        Title = "Pelicula 1",
                        ReleaseDate = DateTime.Now,
                        Genre = "romantica",
                        Price = 7.99M,
                        Rating = "g"
                    
                    },
                     new Movie
                     {
                         Title = "Pelicula 2",
                         ReleaseDate = DateTime.Parse("1989-02-10"),
                         Genre = "romantica",
                         Price = 7.99M,
                         Rating = "r"
                     },
                      new Movie
                      {
                          Title = "Pelicula 3",
                          ReleaseDate = DateTime.Parse("2000-04-10"),
                          Genre = "romantica",
                          Price = 7.99M,
                          Rating = "a"
                      }

                    );

                context.SaveChanges();
            }
        }

    }
}
