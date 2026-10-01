using MvcMovie.Data;
namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(MvcMovieContext context)
    {
        if (context.Movie.Any()) return;
        context.Movie.AddRange(
            new Movie { Title = "Kevade", ReleaseDate = new DateTime(1969, 1, 1), Genre = "Draama", Price = 7.99M, Rating = "G" },
            new Movie { Title = "Suvi", ReleaseDate = new DateTime(1976, 1, 1), Genre = "Komöödia", Price = 8.99M, Rating = "G" },
            new Movie { Title = "Inception", ReleaseDate = new DateTime(2010, 7, 16), Genre = "Ulme", Price = 9.99M, Rating = "PG-13" },
            new Movie { Title = "Interstellar", ReleaseDate = new DateTime(2014, 11, 7), Genre = "Ulme", Price = 12.99M, Rating = "PG-13" });
        context.SaveChanges();
    }
}
