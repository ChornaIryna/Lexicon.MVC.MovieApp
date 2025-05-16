using MovieApp.Web.Interfaces;
using MovieApp.Web.Models;

namespace MovieApp.Web.Services;

public class MovieService : IMovieService
{
    private static List<Movie> _movies = [
        new Movie
        {
            Id = 1,
            Title = "Life of a King",
            Genre = "Drama",
            PosterIdentifier = "tUFktosjXRQ",
            VideoIdentifier = "6uhjh7SK45c",
            ReleaseYear = 2013
        },
        new Movie
        {
            Id = 2,
            Title = "Heretic",
            Genre = "Horror",
            PosterIdentifier = "AxBSbLzl66M",
            VideoIdentifier = "AxBSbLzl66M&pp=sAQB",
            ReleaseYear = 2024
        }
        ];

    public void AddMovie(Movie movie)
    {
        movie.Id = _movies.Count > 0 ? _movies.Max(m => m.Id) + 1 : 1;
        _movies.Add(movie);
    }

    public void DeleteMovie(int id) => _movies.Remove(GetMovieById(id));
    public List<Movie> GetAllMovies() => _movies.OrderByDescending(m => m.ReleaseYear).ToList();

    public Movie GetMovieById(int id) => _movies.Single(m => m.Id == id);

    public void UpdateMovie(Movie movie)
    {
        var existingMovie = GetMovieById(movie.Id);
        existingMovie.Title = movie.Title;
        existingMovie.Genre = movie.Genre;
        existingMovie.PosterIdentifier = movie.PosterIdentifier;
        existingMovie.VideoIdentifier = movie.VideoIdentifier;
        existingMovie.ReleaseYear = movie.ReleaseYear;
    }
}
