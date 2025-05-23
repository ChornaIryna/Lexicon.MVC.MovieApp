using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Interfaces;
using MovieApp.Web.Models;
using MovieApp.Web.ViewModels;

namespace MovieApp.Web.Controllers;

public class MovieController(IMovieService movieService) : Controller
{

    [HttpGet("")]
    public IActionResult Index() =>
        View(new MovieListViewModel
        {
            Movies = [.. movieService.GetAllMovies()
                                                        .Select(m => new MovieViewModel
                                                        {
                                                            Id = m.Id,
                                                            Title = m.Title,
                                                            Genre = m.Genre,
                                                            PosterIdentifier = m.PosterIdentifier,
                                                            VideoIdentifier = m.VideoIdentifier,
                                                            ReleaseYear = m.ReleaseYear,
                                                        })]
        });

    [HttpGet("/movie/{id}")]
    public IActionResult Details(int id)
    {

        var movie = movieService.GetMovieById(id);
        if (movie == null) return NotFound();
        var viewModel = new MovieDetailsViewModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            PosterIdentifier = movie.PosterIdentifier,
            VideoIdentifier = movie.VideoIdentifier,
            ReleaseYear = movie.ReleaseYear
        };
        return View(viewModel);
    }

    [HttpGet("create")]
    public IActionResult Create() => View();

    [HttpPost("create")]
    public IActionResult Create(MovieCreateViewModel newMovie)
    {
        if (!ModelState.IsValid) return View(newMovie);

        var movie = new Movie
        {
            Title = newMovie.Title,
            Genre = newMovie.Genre,
            PosterIdentifier = newMovie.PosterIdentifier,
            VideoIdentifier = newMovie.VideoIdentifier,
            ReleaseYear = newMovie.ReleaseYear
        };
        movieService.AddMovie(movie);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit(int id)
    {
        var movie = movieService.GetMovieById(id);
        if (movie == null) return NotFound();
        var viewModel = new MovieEditViewModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            PosterIdentifier = movie.PosterIdentifier,
            VideoIdentifier = movie.VideoIdentifier,
            ReleaseYear = movie.ReleaseYear
        };
        return View(viewModel);
    }

    [HttpPost("edit/{id}")]
    public IActionResult Edit(int id, MovieEditViewModel updatedMovie)
    {
        if (!ModelState.IsValid) return View(updatedMovie);
        var movie = movieService.GetMovieById(id);
        if (movie == null) return NotFound();

        movie.Title = updatedMovie.Title;
        movie.Genre = updatedMovie.Genre;
        movie.PosterIdentifier = updatedMovie.PosterIdentifier;
        movie.VideoIdentifier = updatedMovie.VideoIdentifier;
        movie.ReleaseYear = updatedMovie.ReleaseYear;

        movieService.UpdateMovie(movie);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var movie = movieService.GetMovieById(id);
        if (movie == null) return NotFound();
        movieService.DeleteMovie(id);
        return RedirectToAction(nameof(Index));
    }
}
