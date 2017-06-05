using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies
                if (context.Movie.Any()) {
                    return; // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie { Title = "Batman", ReleaseDate = DateTime.Parse("1999-1-1"), Genre = "Action", Price = 12.25M},
                    new Movie { Title = "Superman", ReleaseDate = DateTime.Parse("2001-2-3"), Genre = "Action", Price = 11.75M},
                    new Movie { Title = "Green Lantern", ReleaseDate = DateTime.Parse("2002-8-5"), Genre = "Action", Price = 21.30M },
                    new Movie { Title = "GhostBusters", ReleaseDate = DateTime.Parse("1994-5-6"), Genre = "Comedy", Price = 18.64M }
                );

                context.SaveChanges();
            }
        }
    }
}
