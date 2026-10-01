using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class MoviesController(MvcMovieContext context) : Controller
{
    public async Task<IActionResult> Index(string? movieGenre, string? searchString)
    {
        var movies = context.Movie.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(searchString))
            movies = movies.Where(m => m.Title.Contains(searchString));
        if (!string.IsNullOrWhiteSpace(movieGenre))
            movies = movies.Where(m => m.Genre == movieGenre);
        return View(new MovieGenreViewModel
        {
            Movies = await movies.OrderBy(m => m.Title).ToListAsync(),
            Genres = new SelectList(await context.Movie.Select(m => m.Genre).Distinct().OrderBy(g => g).ToListAsync()),
            MovieGenre = movieGenre,
            SearchString = searchString
        });
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var movie = await context.Movie.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        return movie == null ? NotFound() : View(movie);
    }

    public IActionResult Create() => View(new Movie { ReleaseDate = DateTime.Today });

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
    {
        if (!ModelState.IsValid) return View(movie);
        context.Add(movie);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var movie = await context.Movie.FindAsync(id);
        return movie == null ? NotFound() : View(movie);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
    {
        if (id != movie.Id) return NotFound();
        if (!ModelState.IsValid) return View(movie);
        try
        {
            context.Update(movie);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await context.Movie.AnyAsync(m => m.Id == id)) return NotFound();
            throw;
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var movie = await context.Movie.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        return movie == null ? NotFound() : View(movie);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await context.Movie.FindAsync(id);
        if (movie == null) return NotFound();
        context.Movie.Remove(movie);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
