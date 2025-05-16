using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Interfaces;
using MovieApp.Web.Models;
using MovieApp.Web.ViewModels;

namespace MovieApp.Web.Controllers;

public class MovieController(IMovieService movieService) : Controller
{
    private readonly IMovieService _movieService = movieService;

    [HttpGet("")]
    public IActionResult Index() => View(new MovieListViewModel { Movies = _movieService.GetAllMovies() });

    [HttpGet("movie/{id}")]
    public IActionResult Details(int id)
    {
        var movie = _movieService.GetMovieById(id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    [HttpGet("movie/create")]
    public IActionResult Create() => View();

    [HttpPost("movie/create")]
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
        _movieService.AddMovie(movie);

        return RedirectToAction(nameof(Index));
    }
}
